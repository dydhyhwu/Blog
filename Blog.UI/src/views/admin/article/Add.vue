<template>
    <v-container class="full-height">
        <v-responsive class="mx-2" max-width="300px">
            <v-text-field
                v-model="article.title"
                placeholder="起一个响亮的标题吧"
            ></v-text-field>
        </v-responsive>
        <markdown-editor v-model="article.content"></markdown-editor>
        <v-row class="my-2">
            <v-spacer></v-spacer>
            <v-btn color="primary" outlined @click="save">保存</v-btn>
        </v-row>
    </v-container>
</template>

<script lang="ts">
    import { Component, Inject } from 'vue-property-decorator';
    import { RouteName } from 'ea-router';
    import { AddArticle } from '@/domain/views';
    import { Article, ContentFormat } from '@/models/Article';
    import { Repository } from '@/domain/providers';
    import { Repositories } from '@/infrastructure/repository';
    import MarkdownEditor from '@/components/editor';
    import BasePage from '@/infrastructure/basePage';

    @RouteName(AddArticle)
    @Component({
        components: {
            MarkdownEditor,
        },
    })
    export default class AddArticlePage extends BasePage {
        @Inject(Repository) repository: Repositories;

        article: Article = {
            title: '',
            content: '',
            format: ContentFormat.Markdown,
        };

        async save() {
            await this.repository.Article.Add(this.article);
            this.message.success('保存成功');
        }
    }
</script>
