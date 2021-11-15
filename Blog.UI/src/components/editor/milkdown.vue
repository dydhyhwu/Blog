<template>
    <div ref="editor"></div>
</template>

<script lang="ts">
    import { Vue, Component, Ref, VModel } from 'vue-property-decorator';
    import { defaultValueCtx, Editor, rootCtx } from '@milkdown/core';
    import { listenerCtx, listener } from '@milkdown/plugin-listener';
    import { nord } from '@milkdown/theme-nord';
    import { commonmark } from '@milkdown/preset-commonmark';

    @Component
    export default class MilkdownEditor extends Vue {
        @Ref('editor') readonly editor: any;

        @VModel() content: string;

        instance: Editor | null = null;

        listener = {
            markdown: [
                (getMarkdown) => {
                    const value = getMarkdown();
                    this.content = value;
                },
            ],
        };

        mounted() {
            this.init();
        }

        private async init() {
            this.instance = await Editor.make()
                .config((ctx) => {
                    ctx.set(rootCtx, this.editor);
                    ctx.set(defaultValueCtx, this.content);
                    ctx.set(listenerCtx, this.listener);
                })
                .use(nord)
                .use(commonmark)
                .use(listener)
                .create();
        }
    }
</script>
