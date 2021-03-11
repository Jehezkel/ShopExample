<template>
  <div
    v-if="productList != null"
    id="productlist"
    class="row row-cols-lg-5 row-cols-xs-1"
  >
    <ProductCard
      v-for="product in productList.products"
      :key="product.productId"
      :product="product"
    />
  </div>
</template>

<script>
import ProductServices from "@/services/ProductServices.js";
import ProductCard from "@/components/ProductCard.vue";
export default {
  components: {
    ProductCard
  },
  data() {
    return { productList: null };
  },
  mounted() {
    ProductServices.getProducts().then(response => {
      this.productList = response.data;
    });
  }
};
</script>

<style scoped></style>
