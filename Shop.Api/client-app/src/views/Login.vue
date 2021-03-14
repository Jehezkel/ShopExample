<template>
  <div>
    <b-button v-google-signin-button="clientId" variant="primary" class="mt-3"
      >Zaloguj przez konto Google</b-button
    >
  </div>
</template>

<script>
export default {
  data() {
    return {
      clientId:
        "419383006032-eqpfsa8ectgfgqdq5j7c3jt9fohp960l.apps.googleusercontent.com"
    };
  },
  methods: {
    OnGoogleAuthSuccess(idToken) {
      console.log(idToken);
    },
    OnGoogleAuthFail(error) {
      console.log(error);
    }
  }
};
</script>

<style lang="scss" scoped></style>
