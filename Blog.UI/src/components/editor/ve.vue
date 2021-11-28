<template>
    <div id="editor"></div>
</template>

<script lang="ts">
    import { Vue, Component, VModel, Ref } from 'vue-property-decorator';
    import Vditor from 'vditor';
    import 'vditor/dist/index.css';

    @Component
    export default class VEditorComponent extends Vue {
        @VModel({ type: String, default: '' }) content: string;

        instance: any = null;

        mounted() {
            this.init();
        }

        private init() {
            this.instance = new Vditor('editor', {
                icon: 'material',
                value: this.content,

                input: (value) => this.onValueChanged(value),
            });
        }

        private onValueChanged(value: string) {
            console.log(value);
            this.content = value;
        }
    }
</script>
