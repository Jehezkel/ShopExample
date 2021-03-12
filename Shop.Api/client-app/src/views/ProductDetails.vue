<template>
  <div>
    <h1>Nazwa produktu: {{ product.productName }}</h1>
    <img class="main" :v-cloak="MainImageSrc" :src="MainImageSrc" alt="" />
    <div class="gallery">
      <img
        v-for="image in product.productImages"
        :key="image.ImageId"
        :src="image.fullFilePath"
        @click="MainImageSrc = $event.target.id"
        :id="image.productImageId"
      />
    </div>
    <div class="product-description">
      <p v-html="product.productDescription" />
    </div>
  </div>
</template>

<script>
import ProductServices from "@/services/ProductServices.js";
export default {
  data() {
    return {
      product: {
        productImages: []
      }
    };
  },
  computed: {
    MainImageSrc: {
      get() {
        if (
          this.product.productImages &&
          this.product.productImages.length > 0
        ) {
          return this.product.productImages.find(img => img.isMainImage)
            .fullFilePath;
        } else {
          return "";
        }
      },
      set(imageId) {
        this.product.productImages.find(
          img => img.isMainImage
        ).isMainImage = false;
        this.product.productImages.find(
          img => img.productImageId == imageId
        ).isMainImage = true;
      }
    },
    ProductImages: {
      get() {
        if (
          this.product.productImages &&
          this.product.productImages.length > 0
        ) {
          return this.product.productImages;
        } else {
          console.log("zero images");
          return false;
        }
      }
    }
  },
  mounted() {
    console.log(this.product);
    ProductServices.getProductDetail(this.$route.params.productId).then(
      response => {
        this.product = response.data;
        console.log(this.product);
      }
    );
  }
  // methods: {
  //   swapMain($event) {
  //     this.MainImageSrc = $event.target.id;
  //   }
  // }
};
</script>

<style scoped>
img.main {
  max-width: 48%;
  max-height: 300px;
}
.gallery img {
  max-width: 12%;
}
</style>
