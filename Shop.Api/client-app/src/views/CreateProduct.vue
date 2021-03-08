<template>
  <div>
    <b-form>
      <b-form-group
        description="Pierwsza linia pod zdjeciem produktu."
        class="required"
        label="Nazwa Produktu:"
      >
        <b-form-input
          type="text"
          v-model="product.productName"
          required
        ></b-form-input>
      </b-form-group>
      <b-form-group label="Cena Produktu:">
        <b-form-input
          v-model="product.price"
          @keypress="onlyForCurrency"
          required
        ></b-form-input>
        <b-button type="submit" variant="primary">Submit</b-button>
      </b-form-group>
    </b-form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      product: {}
    };
  },
  methods: {
    onlyForCurrency($event) {
      console.log($event.keyCode); //keyCodes value
      let keyCode = $event.keyCode ? $event.keyCode : $event.which;
      if (
        (keyCode < 48 || keyCode > 57) &&
        (keyCode !== 46 || this.product.price.indexOf(".") != -1)
      ) {
        // 46 is dot
        $event.preventDefault();
      }

      // restrict to 2 decimal places
      if (
        this.product.price != null &&
        this.product.price.indexOf(".") > -1 &&
        this.product.price.split(".")[1].length > 1
      ) {
        $event.preventDefault();
      }
    }
  }
};
</script>

<style scoped></style>
