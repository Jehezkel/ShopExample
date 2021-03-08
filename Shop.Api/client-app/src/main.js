import Vue from "vue";
import App from "./App.vue";
import { BootstrapVue } from "bootstrap-vue";
import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { faCartPlus } from "@fortawesome/free-solid-svg-icons";
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
Vue.config.productionTip = false;
library.add(faCartPlus);
Vue.use(BootstrapVue);
Vue.component("font-awesome-icon", FontAwesomeIcon);
new Vue({
  render: h => h(App)
}).$mount("#app");
