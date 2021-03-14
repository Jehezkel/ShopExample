<template>
  <b-navbar toggleable="lg" variant="dark" type="dark">
    <b-navbar-brand href="#">
      <img
        src="https://placekitten.com/g/30/30"
        class="d-inline-block align-top"
        alt="Kitten"
      />
      ShopExample
    </b-navbar-brand>
    <b-navbar-nav>
      <b-nav-item to="/">ProductList</b-nav-item>
      <b-nav-item to="/Product/new">Creat Product</b-nav-item>
      <b-nav-item to="/Login">Login</b-nav-item>
    </b-navbar-nav>
  </b-navbar>
</template>

<script>
export default {};
</script>

<style scoped></style>
