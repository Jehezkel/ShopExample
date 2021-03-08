<template>
  <div class="col mb-4 mr-4 p-0">
    <div class="card p-3 product-card">
      <img
        class="card-image-top"
        src="https://1.allegroimg.com/s180/067cf4/c8e800d54206a489b9f091ad5351/AQUAEL-Zestaw-Akwarystyczny-AKWARIUM-54L-Pokrywa"
        alt=""
        srcset=""
      />

      <div class="product-info">
        <div class="product-info-text text-left">
          <h6 class="card-title">{{ product.productName }}</h6>
          <p class="cardtext">60 litrow</p>
        </div>
        <div class="card-price-row d-flex justify-between">
          <div class="product-price">
            <p class="cardtext">{{ product.price }}zł</p>
          </div>

          <div class="ml-auto cart-icon">
            <a href="#" class="btn-cart-icon">
              <span><font-awesome-icon icon="cart-plus"/></span
            ></a>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    product: Object
  }
};
</script>

<style scoped>
.card {
  border-radius: 4px;
  background: #fff;
  box-shadow: 0 6px 10px rgba(0, 0, 0, 0.08), 0 0 6px rgba(0, 0, 0, 0.05);
  transition: 0.3s transform cubic-bezier(0.155, 1.105, 0.295, 1.12),
    0.3s box-shadow,
    0.3s -webkit-transform cubic-bezier(0.155, 1.105, 0.295, 1.12);
  padding: 14px 80px 18px 36px;
  cursor: pointer;
  width: 100%;
}

.card:hover {
  /* transform: scale(1.05); */
  box-shadow: 0 10px 20px rgba(0, 0, 0, 0.12), 0 4px 8px rgba(0, 0, 0, 0.06);
}
/* a.cart-icon {
  width: 3.8rem;
  height: 3.8rem;
} */
div.product-card img {
  min-width: 156px;
  min-height: 130px;
  margin-bottom: 0.5rem;
  width: 100%;
  object-fit: cover;
}
div.cart-icon svg {
  /* color: black; */
  text-align: center;
  vertical-align: middle;
  position: relative;
  top: 2px;
  height: 20px;
  width: 20px;
}
div.cart-icon a {
  border: 1px solid;
  border-radius: 50%;
  border-color: white;
  line-height: 20px;
  padding: 8px;
  color: white;
}
.product-card:hover div.cart-icon a,
.product-card:hover div.cart-icon span {
  color: rgb(19, 172, 0);
  border-color: rgb(19, 172, 0);
}
div.cart-icon span {
  color: white;
  font-size: 20px;
}
.product-card:hover div.cart-icon:hover span,
.product-card:hover div.cart-icon:hover a {
  color: white;
  background-color: rgb(19, 172, 0);
}
div.product-info p,
div.product-info h6 {
  padding: 0;
  margin: 0;
}
div.product-info-text {
  margin-bottom: 1rem;
}
div.product-info {
  font-size: 14px;
}
</style>
