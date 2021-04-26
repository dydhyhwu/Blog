<template>
    <div>
        <div v-if="article">
            <div>{{ article.title }}</div>
            <v-divider></v-divider>
            <div>
                {{ article.content }}
            </div>
        </div>
    </div>
</template>

<script lang="ts">
    import { Vue, Component, Prop, Inject } from 'vue-property-decorator';
    import { Context, EnableProp, RouteName } from 'ea-router';
    import { ArticleDetail } from '@/domain/views';
    import { Repository } from '@/domain/providers';
    import { Repositories } from '@/infrastructure/repository';
    import { Article } from '@/models/Article';

    @RouteName(ArticleDetail)
    @Context('id')
    @EnableProp()
    @Component
    export default class ArticleDetailPage extends Vue {
        @Inject(Repository) repository: Repositories;
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
