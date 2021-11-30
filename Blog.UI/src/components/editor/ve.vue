<template>
    <div id="editor"></div>
</template>

<script lang="ts">
    import { Vue, Component, VModel, Ref, Watch } from 'vue-property-decorator';
    import Vditor from 'vditor';
    import 'vditor/dist/index.css';

    @Component
    export default class VEditorComponent extends Vue {
        @VModel({ type: String, default: '' }) content!: string;

        instance: Vditor | null = null;

        mounted() {
            this.init();
        }

        @Watch('value', { immediate: true }) onValueInit() {
            this.instance?.setValue(this.content);
        }

        private init() {
            this.instance = new Vditor('editor', {
                icon: 'material',
                value: this.content,
                minHeight: 460,
                placeholder: '',

                input: (value) => this.onValueChanged(value),
                after: () => this.afterInit(),
            });
        }

        private afterInit() {
            this.instance?.setValue(this.content);
        }

        private onValueChanged(value: string) {
            this.content = value;
        }
    }
</script>
