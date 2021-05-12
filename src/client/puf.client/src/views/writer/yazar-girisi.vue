<template>
  <div class="row h-100">
    <div class="text-center col-12">
      <div v-if="tried == true">
        <div
          class="alert alert-danger fade show"
          role="alert"
          v-if="success == false"
        >
          <h5 class="text-center">
            <i class="fas fa-times mr-4"></i>Kullanıcı Adı Veya Şifre Yanlış!
          </h5>
        </div>
        <div class="alert alert-success fade show" role="alert" v-else>
          <h5 class="text-center">
            <i class="fas fa-check-double mr-4"></i>Giriş Başarılı ! Hesabınıza
            Yönlendiriliyorsunuz...<span class="float-right text-danger">{{
              displayname
            }}</span>
          </h5>
        </div>
      </div>

      <div class="form-signin">
        <img
          class="mb-4"
          src="../../../public/pufbilgi_logo.png"
          alt=""
          width="225"
          height="55"
        />
        <h1 class="h3 mb-3 font-weight-normal">Lütfen Giriş Yapın</h1>
        <input
          type="text"
          id="userName"
          class="form-control"
          placeholder="Kullanıcı Adı"
          v-model="username"
        />
        <input
          type="password"
          id="inputPassword"
          class="form-control"
          placeholder="Şifre"
          v-model="password"
        />

        <button class="btn btn-lg btn-primary btn-block" @click="login">
          Giriş Yap
        </button>
        <p class="mt-5 mb-3 text-muted">
          Yazar değil misin?
          <router-link to="/writer/yazar-ol">Yazar Ol</router-link>
        </p>
        <p class="mt-5 mb-3 text-muted">© 2021-2022</p>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import session from "../../helpers/session";
export default {
  name: "yazar-girisi",
  data() {
    return {
      username: "",
      password: "",
      displayname: "",
      success: true,
      tried: false,
      isAuthenticated: false,
    };
  },
  mounted() {
    if (session.isAuthenticated()) {
      this.$router.push("/writer/profilim");
    }
  },
  methods: {
    login() {
      axios
        .post(process.env.VUE_APP_API_URL + "/Management/Writer/login", {
          username: this.username,
          password: this.password,
        })
        .then((response) => {
          this.tried = true;
          this.success = true;
          session.authenticate(response.data);
          this.displayname = session.getSession().displayName;
          setTimeout(() => {
            this.$router.push("/writer/profilim");
            location.reload();
          }, 3000);
        })
        .catch((error) => {
          if (error.response.status === 400) {
            this.tried = true;
            this.success = false;
            this.username = "";
            this.password = "";
          } else {
            alert("ters giden birşeyler var" + error.response);
          }
        });
    },
  },
};
</script>

<style scoped>
.form-signin {
  width: 100%;
  max-width: 330px;
  padding: 15px;
  margin: 0 auto;
  margin-top: 15%;
}
.form-signin .form-control {
  position: relative;
  box-sizing: border-box;
  height: auto;
  padding: 10px;
  font-size: 16px;
}
.form-signin .form-control:focus {
  z-index: 2;
}
.form-signin input[type="text"] {
  margin-bottom: -1px;
  border-bottom-right-radius: 0;
  border-bottom-left-radius: 0;
}
.form-signin input[type="password"] {
  margin-bottom: 10px;
  border-top-left-radius: 0;
  border-top-right-radius: 0;
}
</style>

