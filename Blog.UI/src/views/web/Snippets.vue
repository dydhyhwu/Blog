<template>
    <div class="full-height">
        <v-container>
            <v-data-table
                :headers="headers"
                :items="list"
                hide-default-footer
                disable-sort
                disable-pagination
                disable-filtering
            >
                <template #item.language="{ item }">
                    <v-chip color="primary">{{ item.language }}</v-chip>
                </template>
                <template #item.options="{ item }">
                    <v-btn text depressed @click="view(item)">查看</v-btn>
                </template>
            </v-data-table>
            <v-pagination
                class="float-right"
                v-model="page.index"
                :length="page.page"
            ></v-pagination>
        </v-container>
    </div>
</template>

<script lang="ts">
    import { Component, Watch } from 'vue-property-decorator';
    import { RouteName } from 'ea-router';
    import { CodeSnippetDetail, CodeSnippets } from '@/domain/views';
    import BasePage from '@/infrastructure/basePage';
    import { SnippetItem } from '@/models/Snippet';
    import { Page } from '../../domain/page';

    @RouteName(CodeSnippets)
    @Component
    export default class CodeSnippetsPage extends BasePage {
        list: SnippetItem[] = [];
        headers = [
            { text: '标题', value: 'title' },
            { text: '语言', value: 'language' },
            { text: '创建时间', value: 'createTime' },
            { text: '', value: 'options' },
        ];
        page: Page = new Page();

        @Watch('page.index', { immediate: true, deep: true })
        async onPageIndexChanged(): Promise<void> {
            const { page, count, data } = await this.repository.Snippet.List(
                this.page
            );
            this.list = data;
            this.page.page = page;
            this.page.count = count;
        }

        view(item: SnippetItem): void {
            this.navigator.redirect(CodeSnippetDetail, {
                id: item.id,
            });
        }
    }
</script>
