<template>
    <v-container>
        <div v-if="article">
            <div class="text-center text-h4">
                {{ article.title }}
            </div>
            <v-divider class="my-5" inset></v-divider>
            <content-render :content="article.content"></content-render>
        </div>
    </v-container>
</template>

<script lang="ts">
    import { Component, Prop } from 'vue-property-decorator';
    import { Context, EnableProp, RouteName } from 'ea-router';
    import { ArticleDetail } from '@/domain/views';
    import { Article } from '@/models/Article';
    import ContentRender from '@/components/render';
    import BasePage from '@/infrastructure/basePage';

    @RouteName(ArticleDetail)
    @Context('id')
    @EnableProp()
    @Component({
        components: {
            ContentRender,
        },
    })
    export default class ArticleDetailPage extends BasePage {
        @Prop() id: string;

        article: Article = null;

        mounted() {
            this.init();
        }

        async init() {
            this.article = await this.repository.Article.Get(this.id);
        }
    }
</script>
