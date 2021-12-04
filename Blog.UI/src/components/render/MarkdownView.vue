<template>
    <div v-html="renderContent"></div>
</template>

<script>
    import { Vue, Component, Prop } from 'vue-property-decorator';
    import MarkdownIt from 'markdown-it';
    import Emoji from 'markdown-it-emoji';
    import sub from 'markdown-it-sub';
    import sup from 'markdown-it-sup';
    import deflist from 'markdown-it-deflist';
    import abbr from 'markdown-it-abbr';
    import footnote from 'markdown-it-footnote';
    import insert from 'markdown-it-ins';
    import mark from 'markdown-it-mark';
    import container from 'markdown-it-container';

    @Component
    export default class MarkdownView extends Vue {
        @Prop() content;

        render = new MarkdownIt()
            .use(Emoji)
            .use(sub)
            .use(sup)
            .use(deflist)
            .use(abbr)
            .use(footnote)
            .use(insert)
            .use(mark)
            .use(container);

        get renderContent() {
            return this.render.render(this.content);
        }
    }
</script>
