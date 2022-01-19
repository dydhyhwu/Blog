<template>
    <div ref="editor" class="editor"></div>
</template>

<script lang="ts">
    import { Vue, Component, Ref } from 'vue-property-decorator';
    import * as monaco from 'monaco-editor';

    @Component
    export default class CodeEditor extends Vue {
        @Ref() readonly editor: HTMLDivElement;

        instance: any;

        mounted(): void {
            this.init();
        }

        private init() {
            this.instance = monaco.editor.create(this.editor, {
                value: '',
                language: 'javascript',
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
