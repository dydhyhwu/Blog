<template>
    <div ref="editor" class="editor"></div>
</template>

<script lang="ts">
    import {
        Vue,
        Component,
        Ref,
        Model,
        ModelSync,
    } from 'vue-property-decorator';
    import * as monaco from 'monaco-editor';

    @Component
    export default class CodeEditor extends Vue {
        @Ref() readonly editor: HTMLDivElement;
        @ModelSync('value', 'input') content;

        instance: any;

        mounted(): void {
            this.init();
        }

        private init() {
            this.instance = monaco.editor.create(this.editor, {
                value: this.content,
                language: 'javascript',
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
