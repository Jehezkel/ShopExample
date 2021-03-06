import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import GoogleSignInButton from "vue-google-signin-button-directive";
import { BootstrapVue } from "bootstrap-vue";
import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { faCartPlus } from "@fortawesome/free-solid-svg-icons";
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
Vue.config.productionTip = false;
Vue.use(BootstrapVue);
Vue.use(GoogleSignInButton);
library.add(faCartPlus);

Vue.component("font-awesome-icon", FontAwesomeIcon);
new Vue({
  router,
  GoogleSignInButton,
  render: h => h(App)
}).$mount("#app");
