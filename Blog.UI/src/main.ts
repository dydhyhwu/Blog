import Vue from 'vue';
import App from './App.vue';
import router from './router';
import vuetify from './plugins/vuetify';
import Startup from '@/infrastructure/startup';
import install from 'vuetify-extension';

Vue.config.productionTip = false;

install(Vue, vuetify);
Startup.init();

new Vue({
    router,
    vuetify,
    render: (h) => h(App),
}).$mount('#app');
