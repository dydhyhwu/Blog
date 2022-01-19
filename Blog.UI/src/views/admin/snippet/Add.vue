<template>
    <v-container>
        <v-row>
            <v-text-field
                v-model="snippet.title"
                placeholder="起一个独一无二的名字吧"
            ></v-text-field>
        </v-row>
        <v-row>
            <v-text-field
                v-model="snippet.language"
                placeholder="选择语言"
            ></v-text-field>
        </v-row>
        <v-row>
            <code-editor></code-editor>
        </v-row>
        <v-row>
            <v-spacer></v-spacer>
            <v-btn @click="submit">提交</v-btn>
        </v-row>
    </v-container>
</template>

<script lang="ts">
    import { Component } from 'vue-property-decorator';
    import { RouteName } from 'ea-router';
    import { AddCodeSnippet, CodeSnippetManage } from '@/domain/views';
    import BasePage from '@/infrastructure/basePage';
    import { AddSnippet } from '@/models/Snippet';
    import { CodeEditor } from '@/components/editor';
    import { OnFinishedSuccess, WithLoading } from '@dydhyh/ui-tools';

    @RouteName(AddCodeSnippet)
    @Component({
        components: {
            CodeEditor,
        },
    })
    export default class AddCodeSnippetPage extends BasePage {
        snippet: AddSnippet = { content: '', language: '', title: '' };

        @OnFinishedSuccess('添加成功')
        @WithLoading('提交中')
        async submit(): Promise<void> {
            await this.repository.Snippet.Add(this.snippet);
            this.navigator.redirect(CodeSnippetManage);
        }
    }
</script>
