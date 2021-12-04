<template>
    <div class="fill-height">
        <v-container>
            <v-row>
                <v-col>
                    <v-card
                        v-for="(article, index) in articles"
                        :key="index"
                        class="mb-2"
                        width="60vw"
                        min-height="17vh"
                    >
                        <v-card-title @click="detail(article.id)">
                            {{ article.title }}
                        </v-card-title>
                        <v-card-subtitle>
                            {{ article.title }}
                        </v-card-subtitle>
                        <v-divider class="mx-auto" inset></v-divider>
                        <v-card-actions class="mx-4">
                            <v-avatar color="primary" size="25">
                                <span class="white--text">y</span>
                            </v-avatar>
                            <span class="caption mx-1">wjy</span>
                            <span class="caption mx-1">
                                {{ article.createTime }}
                            </span>
                            <v-spacer></v-spacer>
                            <v-btn
                                class="button"
                                color="primary"
                                text
                                @click="detail(article.id)"
                            >
                                阅读全文>
                            </v-btn>
                        </v-card-actions>
                    </v-card>
                </v-col>
                <v-col cols="3">
                    <v-card class="mb-3" min-height="25vh">
                        <v-card-subtitle>若羽</v-card-subtitle>
                    </v-card>
                    <v-card class="mb-3" min-height="25vh">
                        <v-card-subtitle>
                            <v-icon>mdi-folder</v-icon>
                            分类
                        </v-card-subtitle>

                        <v-list dense>
                            <v-list-item-group>
                                <v-list-item>
                                    <v-list-item-icon>
                                        <v-icon>mdi-folder-outline</v-icon>
                                    </v-list-item-icon>
                                    <v-list-item-content>
                                        分类1
                                    </v-list-item-content>
                                    <v-list-item-icon>
                                        <v-chip label>1</v-chip>
                                    </v-list-item-icon>
                                </v-list-item>
                            </v-list-item-group>
                        </v-list>
                    </v-card>

                    <v-card class="mb-3" min-height="30vh">
                        <v-card-subtitle>
                            <v-icon>mdi-folder</v-icon>
                            最新文章
                        </v-card-subtitle>

                        <v-list dense>
                            <v-list-item-group>
                                <v-list-item>
                                    <v-list-item-icon>
                                        <v-icon>mdi-folder-outline</v-icon>
                                    </v-list-item-icon>
                                    <v-list-item-content>
                                        文章1
                                    </v-list-item-content>
                                </v-list-item>
                            </v-list-item-group>
                        </v-list>
                    </v-card>
                </v-col>
            </v-row>
        </v-container>
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
