<template>
    <div class="full-height">
        <v-container>
            <v-chip
                v-for="(category, index) in list"
                :key="index"
                rounded
                color="primary"
                outlined
            >
                {{ category.name }}
            </v-chip>
        </v-container>
    </div>
</template>

<script lang="ts">
    import { Component } from 'vue-property-decorator';
    import { RouteName } from 'ea-router';
    import { Categories } from '@/domain/views';
    import BasePage from '@/infrastructure/basePage';
    import { Category } from '../../domains/Category';

    @RouteName(Categories)
    @Component
    export default class extends BasePage {
        list: Category[] = [];

        mounted(): void {
            this.loadList();
        }

        async loadList(): Promise<void> {
            this.list = await this.repository.Category.All();
        }
    }
</script>
