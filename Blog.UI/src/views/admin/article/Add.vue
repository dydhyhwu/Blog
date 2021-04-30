<template>
    <v-container class="full-height">
        <v-responsive class="mx-2" max-width="300px">
            <v-text-field
                v-model="article.title"
                placeholder="起一个响亮的标题吧"
            ></v-text-field>
        </v-responsive>
        <mavon-editor v-model="article.content"></mavon-editor>
        <v-row class="my-2">
            <v-spacer></v-spacer>
            <v-btn color="primary" outlined @click="save">保存</v-btn>
        </v-row>
    </v-container>
</template>

<script lang="ts">
    import { Component, Inject, Vue } from 'vue-property-decorator';
    import { RouteName } from 'ea-router';
    import { AddArticle } from '@/domain/views';
    import 'mavon-editor/dist/css/index.css';
    import { Article, ContentFormat } from '@/models/Article';
    import { Repository } from '@/domain/providers';
    import { Repositories } from '@/infrastructure/repository';
    import { Notification } from 'vuetify-extension';

    @RouteName(AddArticle)
    @Component
    export default class AddArticlePage extends Vue {
        @Inject(Repository) repository: Repositories;

        article: Article = {
            title: '',
            content: '',
            format: ContentFormat.Markdown,
        };

        async save() {
            await this.repository.Article.Add(this.article);
            Notification.success('保存成功');
        }
    }
</script>
