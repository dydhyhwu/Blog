<template>
    <div class="full-height">
        <v-data-table :headers="headers" :items="articles" hide-default-footer>
            <template #top>
                <v-row no-gutters align="center" class="mx-2">
                    <v-col>
                        <v-btn color="blue" tile dark :to="AddArticleRoute">
                            <v-icon small>mdi-plus</v-icon>
                            新增
                        </v-btn>
                    </v-col>
                    <v-spacer></v-spacer>
                    <div></div>
                </v-row>
            </template>

            <template #item.options="{ item }">
                <div>
                    <v-btn small text depressed @click="edit(item)">编辑</v-btn>
                </div>
            </template>
        </v-data-table>
    </div>
</template>

<script lang="ts">
    import { Vue, Component, Inject } from 'vue-property-decorator';
    import { RouteName } from 'ea-router';
    import { ArticleManage, AddArticle, EditArticle } from '@/domain/views';
    import { ArticleListItem } from '@/models/Article';
    import { Page } from '@/domain/page';
    import { Repository, Navigator } from '@/domain/providers';
    import { Repositories } from '@/infrastructure/repository';
    import { Navigation } from '@/infrastructure/navigator';

    @RouteName(ArticleManage)
    @Component
    export default class ArticleManagePage extends Vue {
        @Inject(Repository) repository: Repositories;
        @Inject(Navigator) navigator: Navigation;

        get AddArticleRoute() {
            return {
                name: AddArticle,
            };
        }

        headers = [
            {
                text: '标题',
                value: 'title',
            },
            {
                text: '创建时间',
                value: 'createTime',
            },
            {
                text: '操作',
                value: 'options',
            },
        ];
        articles: ArticleListItem[] = [];
        page: Page = new Page();

        mounted() {
            this.init();
        }

        async init() {
            let response = await this.repository.Article.List(this.page);
            this.page.count = response.count;
            this.page.page = response.page;
            this.articles = response.data;
        }

        edit(item: ArticleListItem): void {
            this.navigator.redirect(EditArticle, {
                id: item.id,
            });
        }
    }
</script>
