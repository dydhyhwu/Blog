import Vue from 'vue';
import VueRouter, { RouteConfig } from 'vue-router';
import RouteGenerator from 'ea-router';
import DefaultLayout from '@/components/DefaultLayout.vue';
import PageNotFound from '@/components/PageNotFound.vue';

Vue.use(VueRouter);

const generator = new RouteGenerator(
    require.context('../views/admin', true, /\.vue$/)
);

generator.setDefaultLayout(DefaultLayout);
generator.setNotFoundPage(PageNotFound);

const routes: Array<RouteConfig> = generator.generate();

const router = new VueRouter({
    routes,
});

export default router;
