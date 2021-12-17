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
                    handler: (files: File[]): string | null =>
                        this.OnUploadHandler(files),
                },
            });
        }

        private afterInit() {
            this.instance?.updateValue(this.content);
        }

        private onValueChanged(value: string) {
            this.content = value;
        }

        async OnUploadHandler(files: File[]): null {
            try {
                const list = await this.Upload(files);
                for (const url of list) {
                    this.instance?.insertValue(`![${url}](${url})`);
                }
            } catch (e) {
                this.instance?.tip(e);
                return e;
            }
        }

        async Upload(files: File[]): Promise<string[]> {
            if (files.length <= 0) throw `请选择文件`;
            const list = await CosService.multiUpload(files);
            return list;
        }
    }
</script>
