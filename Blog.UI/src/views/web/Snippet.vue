<template>
    <div class="full-height">
        <v-container v-if="snippet">
            <div class="text-center text-h4">
                {{ snippet.title }}
            </div>
            <v-divider class="my-5" inset></v-divider>
            <v-text-field
                class="language-input"
                readonly
                v-model="snippet.language"
            ></v-text-field>
            <code-render
                :lang="snippet.language"
                :content="snippet.content"
            ></code-render>
        </v-container>
    </div>
</template>

<script lang="ts">
    import { Component, Prop } from 'vue-property-decorator';
    import { Context, EnableProp, RouteName } from 'ea-router';
    import { CodeSnippetDetail } from '@/domain/views';
    import BasePage from '@/infrastructure/basePage';
    import { Snippet } from '@/models/Snippet';
    import { WithLoading } from '@dydhyh/ui-tools';
    import { CodeRender } from '@/components/render';

    @RouteName(CodeSnippetDetail)
    @Context('id')
    @EnableProp()
    @Component({
        components: {
            CodeRender,
        },
    })
    export default class CodeSnippetDetailPage extends BasePage {
        @Prop({ type: String, default: () => '' }) readonly id: string;

        snippet: Snippet | null = null;

        mounted(): void {
            this.init();
        }

        @WithLoading('加载中')
        private async init(): Promise<void> {
            this.snippet = await this.repository.Snippet.Detail(this.id);
        }
    }
</script>

<style lang="css" scoped>
    .language-input {
        width: 130px;
    }
</style>
