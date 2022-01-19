<template>
    <div ref="editor" class="editor"></div>
</template>

<script lang="ts">
    import {
        Vue,
        Component,
        Ref,
        ModelSync,
        Prop,
        Watch,
    } from 'vue-property-decorator';
    import * as monaco from 'monaco-editor';
    import { editor, languages } from 'monaco-editor';
    import IStandaloneCodeEditor = editor.IStandaloneCodeEditor;

    @Component
    export default class CodeEditor extends Vue {
        @Ref() readonly editor: HTMLDivElement;
        @ModelSync('value', 'input') content;
        @Prop({ type: String, default: () => '' }) readonly lang: string;

        instance: IStandaloneCodeEditor | null = null;

        mounted(): void {
            this.init();
        }

        @Watch('lang', { immediate: true, deep: true })
        onLanguageChanged(): void {
            if (!this.instance) return;
            console.log(this.lang, this.instance);
            monaco.editor.setModelLanguage(this.instance.getModel(), this.lang);
        }

        private init() {
            this.instance = monaco.editor.create(this.editor, {
                value: this.content,
                theme: 'vs-dark',
                automaticLayout: true,
            });
            this.instance.onDidChangeModelContent(() => {
                this.content = this.instance.getValue();
            });
        }
    }
</script>

<style lang="css" scoped>
    .editor {
        width: 100%;
        height: 600px;
    }
</style>
