<template>
    <v-container class="full-height">
        <v-responsive class="mx-2" max-width="300px">
            <v-text-field
                v-model="article.title"
                label="标题"
                placeholder="起一个响亮的标题吧"
            ></v-text-field>
        </v-responsive>
        <v-row class="mx-2" no-gutters>
            <v-col cols="2">
                <v-select
                    v-model="article.categories"
                    class="article-setting"
                    label="分类"
                    placeholder="选择文章分类"
                    multiple
                    :items="categories"
                    item-text="name"
                    item-value="id"
                ></v-select>
            </v-col>
        </v-row>
        <markdown-editor v-model="article.content"></markdown-editor>
        <v-row class="my-2">
            <v-spacer></v-spacer>
            <v-btn color="primary" outlined @click="save">保存</v-btn>
        </v-row>
    </v-container>
</template>

<script lang="ts">
    import { Component, Inject, Prop } from 'vue-property-decorator';
    import { Context, EnableProp, RouteName } from 'ea-router';
    import { EditArticle } from '@/domain/views';
    import { ArticleEditModel } from '@/models/Article';
    import { Repository } from '@/domain/providers';
    import { Repositories } from '@/infrastructure/repository';
    import MarkdownEditor from '@/components/editor';
    import BasePage from '@/infrastructure/basePage';
    import { Category } from '@/domains/Category';
    import { WithLoading } from '@dydhyh/ui-tools';

    @RouteName(EditArticle)
    @Context('id')
    @EnableProp()
    @Component({
        components: {
            MarkdownEditor,
        },
    })
    export default class AddArticlePage extends BasePage {
        @Inject(Repository) repository: Repositories;
        @Prop() id;

        article: ArticleEditModel = {
            categories: [],
            content: '',
            id: '',
            title: '',
        };
        categories: Category[] = [];

        async mounted(): Promise<void> {
            await this.init();
            await this.$nextTick();
        }

        @WithLoading('加载中')
        async init(): Promise<void> {
            this.article = await this.repository.Article.Detail(this.id);
            await this.getCategories();
        }

        async getCategories(): Promise<void> {
            let query = {
                page: 1,
                count: 0,
                index: 1,
                size: 30,
            };
            const data = await this.repository.Category.List(query);
            this.categories = data.data;
        }

        async save(): Promise<void> {
            await this.repository.Article.Edit(this.article);
            this.message.success('保存成功');
        }
    }
</script>
