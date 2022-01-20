<template>
    <div ref="editor" class="editor"></div>
</template>

<script lang="ts">
    import { Vue, Component, Ref, Prop } from 'vue-property-decorator';
    import { editor } from 'monaco-editor';
    import IStandaloneCodeEditor = editor.IStandaloneCodeEditor;

    @Component
    export default class MonacoEditorCodeView extends Vue {
        @Ref() readonly editor: HTMLDivElement;
        @Prop({ type: String, default: () => '' }) readonly lang: string;
        @Prop({ type: String, default: () => '' }) readonly content: string;

        instance: IStandaloneCodeEditor | null = null;

        mounted(): void {
            this.init();
        }

        private init() {
            this.instance = editor.create(this.editor, {
                value: this.content,
                language: this.lang,
                readOnly: true,
                theme: 'vs-dark',
                automaticLayout: true,
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
