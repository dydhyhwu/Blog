import Vue from 'vue';
import App from './App.vue';
import router from './router';
import vuetify from './plugins/vuetify';
import Startup from '@/infrastructure/startup';

Vue.config.productionTip = false;

Startup.init();

new Vue({
    router,
    vuetify,
    render: (h) => h(App),
}).$mount('#app');
