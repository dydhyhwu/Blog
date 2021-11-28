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
    import { Component, Inject, Prop, Vue } from 'vue-property-decorator';
    import { Context, EnableProp, RouteName } from 'ea-router';
    import { EditArticle } from '@/domain/views';
    import { ArticleEditModel } from '@/models/Article';
    import { Repository } from '@/domain/providers';
    import { Repositories } from '@/infrastructure/repository';
    import { Notification } from 'vuetify-extension';
    import MarkdownEditor from '@/components/editor';

    @RouteName(EditArticle)
    @Context('id')
    @EnableProp()
    @Component({
        components: {
            MarkdownEditor,
        },
    })
    export default class AddArticlePage extends Vue {
        @Inject(Repository) repository: Repositories;
        @Prop() id;

        article: ArticleEditModel = { content: '', id: '', title: '' };

        async mounted() {
            await this.init();
            await this.$nextTick();
        }

        async init() {
            this.article = await this.repository.Article.Detail(this.id);
        }

        async save() {
            Notification.success('保存成功');
        }
    }
</script>
