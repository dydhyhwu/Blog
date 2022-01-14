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
                    <v-btn
                        color="error"
                        small
                        text
                        depressed
                        @click="remove(item)"
                    >
                        删除
                    </v-btn>
                </div>
            </template>
        </v-data-table>
    </div>
</template>

<script lang="ts">
    import { Component } from 'vue-property-decorator';
    import { RouteName } from 'ea-router';
    import { ArticleManage, AddArticle, EditArticle } from '@/domain/views';
    import { ArticleListItem } from '@/models/Article';
    import { Page } from '@/domain/page';
    import BasePage from '@/infrastructure/basePage';
    import { Confirm, OnFinishedSuccess } from '@dydhyh/ui-tools';

    @RouteName(ArticleManage)
    @Component
    export default class ArticleManagePage extends BasePage {
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

        @Confirm('是否删除,删除后不可恢复')
        @OnFinishedSuccess('删除成功')
        async remove(item: ArticleListItem): Promise<void> {
            await this.repository.Article.Delete(item.id);
            await this.init();
        }
    }
</script>
