import Vue from "vue";
import Router from "vue-router";
import ProductList from "./views/ProductList.vue";
import CreateProduct from "./views/CreateProduct.vue";

Vue.use(Router);
export default new Router({
  routes: [
    {
      path: "/",
      name: "ProductList",
      component: ProductList
    },
    {
      path: "/Product/new",
      name: "CreateProduct",
      component: CreateProduct
    }
  ]
});
