<template>
    <div id="editor"></div>
</template>

<script lang="ts">
    import {
        Vue,
        Component,
        VModel,
        Ref,
        Watch,
        Emit,
    } from 'vue-property-decorator';
    import Vditor from 'vditor';
    import 'vditor/dist/index.css';
    import CosService from '../../infrastructure/CosService';

    @Component
    export default class VEditorComponent extends Vue {
        @VModel({ type: String, default: '' }) content!: string;

        instance: Vditor | null = null;

        async mounted() {
            await this.$nextTick();
            this.init();
        }

        @Watch('value', { immediate: true })
        onValueInit() {
            if (this.instance?.getValue() === this.content) return;
            this.instance?.updateValue(this.content);
        }

        private init() {
            this.instance = new Vditor('editor', {
                icon: 'material',
                value: this.content,
                minHeight: 460,
                placeholder: '',

                cache: {
                    enable: false,
                },

                input: (value) => this.onValueChanged(value),
                after: () => this.afterInit(),
                upload: {
                    handler: (files: File[]): string | null => {
                        this.OnUploadHandler(files);
                        return null;
                    },
                },
            });
        }

        private afterInit() {
            this.instance?.updateValue(this.content);
        }

        private onValueChanged(value: string) {
            this.content = value;
        }

        async OnUploadHandler(files: File[]): Promise<null> {
            try {
                const url = await this.Upload(files[0]);
                this.instance?.insertValue(`![${files[0].name}](${url})`);
            } catch (e) {
                this.instance?.tip(e);
                return e;
            }
        }

        async Upload(file: File): Promise<string> {
            const url = await CosService.upload(file);
            return url;
        }
    }
</script>
