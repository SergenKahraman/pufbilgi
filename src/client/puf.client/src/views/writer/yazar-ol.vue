<template>
  <div class="row h-100">
    <div class="text-center col-12">
      <div
        class="alert alert-danger fade show"
        role="alert"
        v-if="
          validatedForBlank == false ||
          validatedForPassword == false ||
          validatedForEmail == false
        "
      >
        <h5 v-if="validatedForBlank == false" class="text-center">
          <i class="fas fa-times-circle mr-3"></i>Lütfen Zorunlu Alanları
          Doldurunuz!
        </h5>
        <h5 v-if="validatedForPassword == false" class="text-center">
          <i class="fas fa-times-circle mr-3"></i>Şifreler Eşleşmiyor!
        </h5>
        <h5 v-if="validatedForEmail == false" class="text-center">
          <i class="fas fa-times-circle mr-3"></i>Email Adresi Formatı Yanlış!
          Örnek: name@domain.com
        </h5>
      </div>

      <div class="form-signin">
        <div
          class="alert alert-success fade show"
          role="alert"
          v-if="success == true"
        >
          <h5 class="text-center">
            <i class="fas fa-check-double mr-4"></i>Mailinize Aktivasyon kodu
            Gönderilmiştir.<br />
            lütfen Mailiniz Kontrol Ediniz !
          </h5>
        </div>
        <div v-else>
          <img
            class="mb-4"
            src="../../../public/pufbilgi_logo.png"
            alt=""
            width="225"
            height="55"
          />
          <h1 class="h3 mb-3 font-weight-normal">
            Yazar Olmak İçin Kayıt Olun
          </h1>
          <div class="form-row">
            <input
              type="text"
              id="userName"
              class="form-control col-md-6"
              placeholder="Adınız *"
              v-model="name"
            />
            <input
              type="text"
              id="name"
              class="form-control col-md-6"
              placeholder="Soyadınız *"
              v-model="surName"
            />
          </div>

          <div class="form-row">
            <input
              type="text"
              id="surName"
              class="form-control"
              placeholder="Kullanıcı Adı *"
              v-model="userName"
            />
            <input
              type="email"
              id="email"
              class="form-control"
              placeholder="Email Adresiniz *"
              v-model="emailAddress"
            />
            <input
              type="text"
              id="job"
              class="form-control"
              placeholder="Mesleğiniz *"
              v-model="job"
            />
            <select class="form-control custom-input" v-on:change="cityChanged">
              <option value="-1" :selected="city == null">
                Şehir Seçiniz *
              </option>
              <option v-for="c in cities" :key="c.code" :value="c.label">
                {{ c.label }}
              </option>
            </select>
            <input
              type="password"
              id="inputPassword"
              class="form-control"
              placeholder="Şifre *"
              v-model="passwordAgain"
            />
            <input
              type="password"
              id="inputPasswordAgain"
              class="form-control"
              placeholder="Şifre Tekrar *"
              v-model="password"
            />
          </div>

          <button class="btn btn-lg btn-primary btn-block" @click="register">
            Kayıt Ol
          </button>
          <p class="mt-5 mb-3 text-muted">
            Zaten Yazar mısın?
            <router-link to="/writer/yazar-girisi">Giriş Yap</router-link>
          </p>
          <p class="mt-5 mb-3 text-muted">© 2021-2022</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import cities from "../writer/cities";
import session from "../../helpers/session";

export default {
  components: {},
  data() {
    return {
      password: "",
      passwordAgain: "",
      city: null,
      job: "",
      name: "",
      surName: "",
      displayName: "",
      userName: "",
      emailAddress: "",

      cities: cities,
      validatedForBlank: true,
      validatedForPassword: true,
      validatedForEmail: true,
      success: false,
    };
  },
  mounted(){
    if (session.isAuthenticated()) {
      this.$router.push("/writer/profilim");
    }
  },
  methods: {
    cityChanged(e) {
      this.city = e.target.value == -1 ? null : e.target.value;
    },
    register() {
      if (
        this.validateBlank() &&
        this.validatePassword() &&
        this.validateEmail()
      ) {
        var newWriter = {
          userName: this.userName,
          password: this.password,
          firstName: this.name,
          lastName: this.surName,
          job: this.job,
          city: this.city,
          emailAddress: this.emailAddress,
        };

        axios
          .post(
            process.env.VUE_APP_API_URL + "/Management/Writer/register",
            newWriter
          )
          .then((response) => {
            if (response.data) {
              this.success = true;
            }
          });
      }
    },
    validateBlank() {
      if (
        this.password != null &&
        this.passwordAgain != null &&
        this.city != null &&
        this.name != null &&
        this.surName != null &&
        this.displayName != null &&
        this.emailAddress != null &&
        this.userName != null
      ) {
        this.validatedForBlank = true;
        return true;
      } else {
        this.validatedForBlank = false;
        return false;
      }
    },
    validatePassword() {
      if (this.passwordAgain === this.password) {
        this.validatedForPassword = true;
        return true;
      } else {
        this.validatedForPassword = false;
        this.password = "";
        this.passwordAgain = "";
        return false;
      }
    },
    validateEmail() {
      if (this.emailAddress.includes("@") && this.emailAddress.includes(".")) {
        this.validatedForEmail = true;
        return true;
      } else {
        this.validatedForEmail = false;
        return false;
      }
    },
  },
  watch: {
    name() {
      this.name = this.name.charAt(0).toUpperCase() + this.name.slice(1);
    },
    surName() {
      this.surName =
        this.surName.charAt(0).toUpperCase() + this.surName.slice(1);
    },
    job() {
      this.job = this.job.charAt(0).toUpperCase() + this.job.slice(1);
    },
  },
};
</script>

<style scoped>
.form-signin {
  width: 100%;
  max-width: 350px;
  padding: 15px;
  margin: 0 auto;
  margin-top: 10%;
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
.form-signin input[type="text"],
.form-signin input[type="email"],
.custom-input {
  margin-bottom: 10px;
  border-bottom-right-radius: 0;
  border-bottom-left-radius: 0;
}
.form-signin input[type="password"] {
  margin-bottom: 10px;
  border-top-left-radius: 0;
  border-top-right-radius: 0;
}
</style>

