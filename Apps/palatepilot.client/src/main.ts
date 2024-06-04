import "./sass/main.scss";
import './assets/main.css'

import { createApp } from "vue";
import { createPinia } from 'pinia'
import App from "./App.vue";
import router from "./router/index";

import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { faCartShopping } from '@fortawesome/free-solid-svg-icons'

/* add icons to the library */
library.add(faCartShopping)


const app = createApp(App);
const pinia = createPinia()

app.component('font-awesome-icon', FontAwesomeIcon)
app.use(router);
app.use(pinia)
app.mount("#app");