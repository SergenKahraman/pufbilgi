<template>
  <div>
    <div class="alert alert-danger">
      <p>Burası Profilim Sayfası, Hoş Geldin <span class="text-success">{{displayName}}</span></p>
    </div>
  </div>
</template>

<script>
import session from '../../helpers/session';
export default {
  name: "profilim",
  data() {
    return {
        displayName:"",
    };
  },
  mounted(){
      if(session.isAuthenticated()){
          this.displayName = session.getSession().displayName;
      }else{
          this.$router.push('/writer/yazar-girisi')
      }
  }
};
</script>

<style scoped>
</style>