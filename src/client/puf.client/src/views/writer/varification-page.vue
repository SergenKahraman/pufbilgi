<template>
  <div class="custom-css">
    <div v-if="isVerified == true && showFlag == true" class="text-center alert alert-success fade show">
      <i class="fas fa-check-double mr-4"></i>
      <h3>Hesabınız Doğrulandı</h3>
      <h5>Giriş Yapmak Üzere Yönlendiriliyorsunuz...</h5>
  </div>
  </div>
  
</template>

<script>
import axios from "axios";
export default {
  name: "varification-page",
  data() {
    return {
      isVerified: false,
      showFlag: false,
    };
  },
  mounted() {
    axios
      .post(
        process.env.VUE_APP_API_URL +
          `/Management/Writer/check/${this.$route.query.code}/${this.$route.query.writerId}`
      )
      .then((response) => {
        if (response.data == true) {
          this.isVerified = true;
          setTimeout(()=>{
            this.$router.push("/writer/yazar-girisi");
          },4000);
        } else {
          this.isVerified = false;
        }
        this.showFlag = true;
      })
      .catch((e) => {
        alert("birşeyler ters gitti, lütfen daha sonra tekrar deneyin.  " + e.response);
      });
  },
};
</script>

<style scoped>
.custom-css{
  width: 100%;
  max-width: 600px;
  padding: 15px;
  margin: 0 auto;
  margin-top: 10%;
}
</style>