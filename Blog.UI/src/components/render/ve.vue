<template>
    <div ref="preview" class="vditor-reset clear-scroll"></div>
</template>

<script lang="ts">
    import { Component, Prop, Ref, Vue, Watch } from 'vue-property-decorator';
    import Vditor from 'vditor';
    import 'vditor/dist/index.css';

    @Component
    export default class VERender extends Vue {
        @Prop() content: string;

        @Ref('preview') preview!: HTMLDivElement;

        config: any = {
            mode: 'light',
            anchor: 1, // 渲染锚点，在标题前
            lazyLoadImage:
                'https://cdn.jsdelivr.net/npm/vditor/dist/images/img-loading.svg',
            markdown: {
                toc: true,
            },
            theme: {},
            hljs: {
                lineNumber: true,
                style: 'xcode',
            },
        };

        @Watch('content', { immediate: true, deep: true })
        async onContentChanged() {
            if (!this.content) return;
            await this.$nextTick();
            if (this.preview) this.renderContent();
        }

        private renderContent() {
            Vditor.preview(this.preview, this.content, this.config);
        }
    }
</script>

<style scoped>
    .clear-scroll {
        overflow: hidden;
    }
</style>
