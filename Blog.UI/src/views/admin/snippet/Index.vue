<template>
    <div class="full-height">
        <v-data-table :headers="headers" :items="items" hide-default-footer>
            <template #top>
                <v-row no-gutters align="center" class="mx-2">
                    <v-col>
                        <v-btn color="blue" tile dark :to="addSnippetRoute">
                            <v-icon small>mdi-plus</v-icon>
                            新增
                        </v-btn>
                    </v-col>
                </v-row>
            </template>
            <template #item.options="{ item }">
                <v-btn
                    class="mx-2"
                    color="error"
                    text
                    depressed
                    @click="remove(item)"
                >
                    删除
                </v-btn>
            </template>
        </v-data-table>
    </div>
</template>

<script lang="ts">
    import { Component, Watch } from 'vue-property-decorator';
    import { RouteName } from 'ea-router';
    import { AddCodeSnippet, CodeSnippetManage } from '@/domain/views';
    import BasePage from '@/infrastructure/basePage';
    import { SnippetItem } from '@/models/Snippet';
    import { Page } from '@/domain/page';
    import { Confirm, OnFinishedSuccess, WithLoading } from '@dydhyh/ui-tools';

    @RouteName(CodeSnippetManage)
    @Component
    export default class CodeSnippetManagePage extends BasePage {
        headers = [
            { text: '标题', value: 'title' },
            { text: '语言', value: 'language' },
            { text: '创建时间', value: 'createTime' },
            { text: '操作', value: 'options' },
        ];

        items: SnippetItem[] = [];
        page: Page = new Page();

        get addSnippetRoute() {
            return {
                name: AddCodeSnippet,
            };
        }

        async loadData(): Promise<void> {
            await this.OnPageIndexChanged();
        }

        @Watch('page.index', { immediate: true, deep: true })
        async OnPageIndexChanged(): Promise<void> {
            const { data, count, page } = await this.repository.Snippet.List(
                this.page
            );
            this.items = data;
            this.page.page = page;
            this.page.count = count;
        }

        @Confirm('删除后不可找回，是否删除？')
        @OnFinishedSuccess('删除成功')
        @WithLoading('删除中')
        async remove(item: SnippetItem): Promise<void> {
            await this.repository.Snippet.Remove(item.id);
            await this.loadData();
        }
    }
</script>
