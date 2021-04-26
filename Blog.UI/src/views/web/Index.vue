<template>
    <div class="fill-height">
        <v-app-bar color="white" app flat>心情题解</v-app-bar>
        <v-main class="grey lighten-3 fill-height">
            <v-container>
                <v-row>
                    <v-col cols="2">
                        <v-sheet rounded>
                            <v-list color="transparent">
                                <v-list-item>
                                    <v-list-item-content>
                                        <v-list-item-title>
                                            分类1
                                        </v-list-item-title>
                                    </v-list-item-content>
                                </v-list-item>

                                <v-list-item>
                                    <v-list-item-content>
                                        <v-list-item-title>
                                            分类2
                                        </v-list-item-title>
                                    </v-list-item-content>
                                </v-list-item>
                            </v-list>
                        </v-sheet>
                    </v-col>
                    <v-col>
                        <v-card
                            v-for="(article, index) in articles"
                            :key="index"
                        >
                            <v-container>
                                <v-row>
                                    <v-col cols="auto">
                                        <v-img>
                                            <v-avatar
                                                color="primary"
                                                tile
                                                size="68"
                                            >
                                                <span
                                                    class="white--text headline"
                                                >
                                                    暂无图片
                                                </span>
                                            </v-avatar>
                                        </v-img>
                                    </v-col>
                                    <v-col align-self="center">
                                        <div
                                            class="title"
                                            @click="detail(article.id)"
                                        >
                                            {{ article.title }}
                                        </div>
                                        <v-divider></v-divider>
                                        <div class="grey--text overline">
                                            <v-icon class="mx-1" small>
                                                mdi-calendar-clock
                                            </v-icon>
                                            <span>
                                                {{ article.createTime }}
                                            </span>

                                            <v-icon class="mx-1" small>
                                                mdi-eye
                                            </v-icon>
                                            <span>888</span>

                                            <v-icon class="mx-1" small>
                                                mdi-folder-open
                                            </v-icon>
                                            <span>分类1</span>

                                            <v-icon class="mx-1" small>
                                                mdi-tag-multiple
                                            </v-icon>
                                            <span>标签1,标签2,标签3</span>
                                        </div>
                                    </v-col>
                                </v-row>
                            </v-container>
                        </v-card>
                    </v-col>
                </v-row>
            </v-container>
        </v-main>
    </div>
</template>

<script lang="ts">
    import { Vue, Component, Inject } from 'vue-property-decorator';
    import { RouteName } from 'ea-router';
    import { ArticleDetail, Home } from '@/domain/views';
    import { Navigator, Repository } from '@/domain/providers';
    import { Repositories } from '@/infrastructure/repository';
    import { Page } from '@/domain/page';
    import { ArticleListItem } from '@/models/Article';
    import { Navigation } from '@/infrastructure/navigator';

    @RouteName(Home)
    @Component
    export default class HomePage extends Vue {
        @Inject(Repository) repository: Repositories;
        @Inject(Navigator) navigator: Navigation;

        page: Page = new Page();
        articles: ArticleListItem[] = [];

        mounted(): void {
            this.init();
        }

        async init() {
            let response = await this.repository.Article.List(this.page);
            this.page.count = response.count;
            this.page.page = response.page;
            this.articles = response.data;
        }

        detail(id: string) {
            this.navigator.redirect(ArticleDetail, {
                id: id,
            });
        }
    }
</script>
