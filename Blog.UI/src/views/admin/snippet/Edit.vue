<template>
    <div class="full-height">
        <v-container v-if="snippet">
            <v-row>
                <v-text-field v-model="snippet.title"></v-text-field>
            </v-row>
            <v-row>
                <v-combobox
                    v-model="snippet.language"
                    :items="langs"
                ></v-combobox>
            </v-row>
            <v-row>
                <code-editor
                    v-model="snippet.content"
                    :lang="snippet.language"
                ></code-editor>
            </v-row>
            <v-row>
                <v-btn color="primary" @click="submit">保存</v-btn>
            </v-row>
        </v-container>
    </div>
</template>

<script lang="ts">
    import { Component, Prop } from 'vue-property-decorator';
    import { Context, EnableProp, RouteName } from 'ea-router';
    import { CodeSnippetManage, EditCodeSnippet } from '@/domain/views';
    import BasePage from '@/infrastructure/basePage';
    import { CodeEditor } from '@/components/editor';
    import { EditSnippet } from '@/models/Snippet';
    import { OnFinishedSuccess } from '@dydhyh/ui-tools';
    import { languages } from 'monaco-editor';

    @RouteName(EditCodeSnippet)
    @Context('id')
    @EnableProp()
    @Component({
        components: {
            CodeEditor,
        },
    })
    export default class EditCodeSnippetPage extends BasePage {
        @Prop({ type: String, default: () => '' }) readonly id: string;

        snippet: EditSnippet | null = null;

        get langs(): string[] {
            return languages.getLanguages().map((x) => x.id);
        }

        mounted(): void {
            this.init();
        }

        private async init(): Promise<void> {
            this.snippet = await this.repository.Snippet.Get(this.id);
        }

        @OnFinishedSuccess('保存成功')
        async submit(): Promise<void> {
            await this.repository.Snippet.Edit(this.snippet);
            this.navigator.redirect(CodeSnippetManage);
        }
    }
</script>
