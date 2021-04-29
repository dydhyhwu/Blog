<template>
    <v-container>
        <div v-if="article">
            <div class="text-center text-h4">
                {{ article.title }}
            </div>
            <v-divider class="my-5" inset></v-divider>
            <markdown-view :value="article.content"></markdown-view>
        </div>
    </v-container>
</template>

<script lang="ts">
    import { Vue, Component, Prop, Inject } from 'vue-property-decorator';
    import { Context, EnableProp, RouteName } from 'ea-router';
    import { ArticleDetail } from '@/domain/views';
    import { Repository } from '@/domain/providers';
    import { Repositories } from '@/infrastructure/repository';
    import { Article } from '@/models/Article';
    import MarkdownView from '@/components/MarkdownView.vue';

    @RouteName(ArticleDetail)
    @Context('id')
    @EnableProp()
    @Component({
        components: {
            MarkdownView,
        },
    })
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
