<template>
  <alert :text="alertText" :level="alertLevel" :id="'alertModal'"></alert>
  <div class="container-flued ml-5 mr-5 mb-2 mt-3">
    <div class="row shadow-sm">
      <h1 class="custom-head ml-4">Profilim</h1>
    </div>
    <div class="row">
      <div class="col-md-7 col-sm-12">
        <div class="card mt-3" v-for="a in articles" :key="a.id">
          <div class="card-body text-center">
            <a :href="a.articleLink">
              <img class="img-fluid" :src="a.preViewPhoto" alt="card image" />
            </a>
            <a :href="a.articleLink"
              ><h4 class="card-title mt-4">{{ a.title }}</h4></a
            >
            <span class="text-muted">{{ a.publishedDate }}</span>
            <p class="card-text mt-1">
              {{ a.summary }}
            </p>
            <a
              :href="a.articleLink"
              title="Oku"
              class="btn btn-outline-primary m-2"
              ><i class="fab fa-readme"></i
            ></a>
            <button
              @click="editArticle"
              title="Düzenle"
              class="btn btn-outline-primary m-2"
            >
              <i class="fas fa-pen-nib"></i>
            </button>
          </div>
        </div>
      </div>
      <div class="col-md-5 col-sm-12">
        <!--profil fotoğrafı bolumu-->

        <div class="card mt-3">
          <div class="card-body">
            <div class="row">
              <div class="col text-right">
                <button @click="editPhoto" class="btn btn-outline-primary mb-3">
                  <i class="fas fa-pen-nib"></i>
                </button>
              </div>
            </div>
            <div class="d-flex flex-column align-items-center text-center">
              <img
                v-if="writer.photoAddress != null"
                :src="writer.photoAddress"
                alt="Admin"
                class="rounded-circle"
                width="150"
              />
              <img
                v-else
                src="https://bootdey.com/img/Content/avatar/avatar7.png"
                alt="Admin"
                class="rounded-circle"
                width="150"
              />
              <div class="mt-3">
                <h4>{{ writer.displayName }}</h4>
                <p class="text-secondary mb-1">{{ writer.job }}</p>
              </div>
            </div>
          </div>
        </div>
        <!--bilgiler bolumu-->

        <div class="card mt-3">
          <div class="card-body">
            <div class="row">
              <div class="col text-right">
                <button @click="editInfo" class="btn btn-outline-primary mb-3">
                  <i class="fas fa-pen-nib"></i>
                </button>
              </div>
            </div>

            <div class="row">
              <div class="col-sm-4 col-md-4">
                <h6 class="mb-0">Adı Soyadı</h6>
              </div>
              <div class="col-sm-8 col-md-8 text-secondary">
                {{ writer.displayName }}
              </div>
            </div>
            <hr />
            <div class="row">
              <div class="col-sm-4">
                <h6 class="mb-0">Email</h6>
              </div>
              <div class="col-sm-8 text-secondary">
                {{ writer.emailAddress }}
              </div>
            </div>
            <hr />
            <div class="row">
              <div class="col-sm-4">
                <h6 class="mb-0">Meslek</h6>
              </div>
              <div class="col-sm-8 text-secondary">{{ writer.job }}</div>
            </div>
            <hr />
            <div class="row">
              <div class="col-sm-4">
                <h6 class="mb-0">Şehir</h6>
              </div>
              <div class="col-sm-8 text-secondary">{{ writer.city }}</div>
            </div>
            <hr />
          </div>
        </div>
        <!--açıklama bolumu-->

        <div class="card mt-3">
          <div class="card-body">
            <div class="row">
              <div class="col text-right">
                <button
                  @click="editDescription"
                  class="btn btn-outline-primary"
                >
                  <i class="fas fa-pen-nib"></i>
                </button>
              </div>
            </div>
            <div class="row">
              <div class="col-sm-12 text-center">
                <h5 class="mb-0">Açıklama</h5>
                <hr />
              </div>
              <div class="col-sm-12 text-secondary text-center mt-1">
                {{ writer.description }}
                <hr />
              </div>
            </div>
          </div>
        </div>

        <!--sosyal medya bolumu-->
        <div class="card mt-3">
          <div class="row card-body">
            <div class="col text-right">
              <button
                @click="editSocialAccount"
                class="btn btn-outline-primary"
              >
                <i class="fas fa-pen-nib"></i>
              </button>
            </div>
          </div>
          <ul class="list-group list-group-flush">
            <li
              class="list-group-item d-flex justify-content-between align-items-center flex-wrap"
            >
              <h6 class="mb-0">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="24"
                  viewBox="0 0 24 24"
                  fill="none"
                  stroke="currentColor"
                  stroke-width="2"
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  class="feather feather-github mr-2 icon-inline"
                >
                  <path
                    d="M9 19c-5 1.5-5-2.5-7-3m14 6v-3.87a3.37 3.37 0 0 0-.94-2.61c3.14-.35 6.44-1.54 6.44-7A5.44 5.44 0 0 0 20 4.77 5.07 5.07 0 0 0 19.91 1S18.73.65 16 2.48a13.38 13.38 0 0 0-7 0C6.27.65 5.09 1 5.09 1A5.07 5.07 0 0 0 5 4.77a5.44 5.44 0 0 0-1.5 3.78c0 5.42 3.3 6.61 6.44 7A3.37 3.37 0 0 0 9 18.13V22"
                  ></path></svg
                >Github
              </h6>
              <span class="text-secondary">{{ writer.github }}</span>
            </li>
            <li
              class="list-group-item d-flex justify-content-between align-items-center flex-wrap"
            >
              <h6 class="mb-0">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="24"
                  viewBox="0 0 24 24"
                  fill="none"
                  stroke="currentColor"
                  stroke-width="2"
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  class="feather feather-twitter mr-2 icon-inline text-info"
                >
                  <path
                    d="M23 3a10.9 10.9 0 0 1-3.14 1.53 4.48 4.48 0 0 0-7.86 3v1A10.66 10.66 0 0 1 3 4s-4 9 5 13a11.64 11.64 0 0 1-7 2c9 5 20 0 20-11.5a4.5 4.5 0 0 0-.08-.83A7.72 7.72 0 0 0 23 3z"
                  ></path></svg
                >Twitter
              </h6>
              <span class="text-secondary">{{ writer.twitter }}</span>
            </li>
            <li
              class="list-group-item d-flex justify-content-between align-items-center flex-wrap"
            >
              <h6 class="mb-0">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="24"
                  viewBox="0 0 24 24"
                  fill="none"
                  stroke="currentColor"
                  stroke-width="2"
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  class="feather feather-instagram mr-2 icon-inline text-danger"
                >
                  <rect x="2" y="2" width="20" height="20" rx="5" ry="5"></rect>
                  <path
                    d="M16 11.37A4 4 0 1 1 12.63 8 4 4 0 0 1 16 11.37z"
                  ></path>
                  <line x1="17.5" y1="6.5" x2="17.51" y2="6.5"></line></svg
                >Instagram
              </h6>
              <span class="text-secondary">{{ writer.instagram }}</span>
            </li>
            <li
              class="list-group-item d-flex justify-content-between align-items-center flex-wrap"
            >
              <h6 class="mb-0">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="24"
                  viewBox="0 0 24 24"
                  fill="none"
                  stroke="currentColor"
                  stroke-width="2"
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  class="feather feather-facebook mr-2 icon-inline text-primary"
                >
                  <path
                    d="M18 2h-3a5 5 0 0 0-5 5v3H7v4h3v8h4v-8h3l1-4h-4V7a1 1 0 0 1 1-1h3z"
                  ></path></svg
                >Facebook
              </h6>
              <span class="text-secondary">{{ writer.facebook }}</span>
            </li>
            <li
              class="list-group-item d-flex justify-content-between align-items-center flex-wrap"
            >
              <h6 class="mb-0">
                <i class="fab fa-linkedin-in fa-lg mr-2 ml-1 text-primary"></i>
                Linkedin
              </h6>
              <span class="text-secondary">{{ writer.linkedin }}</span>
            </li>
          </ul>
        </div>
      </div>
    </div>
  </div>
  <profil-info-modal
    :displayName="writer.displayName"
    :job="writer.job"
    :emailAddress="writer.emailAddress"
    :city="writer.city"
    @clicked="saveChangesForInfo"
  ></profil-info-modal>
  <profil-description-modal
    :description="writer.description"
    @clicked="saveChangesForDescription"
  ></profil-description-modal>
  <profil-social-account-modal
    @clicked="saveChangesForSocialAccounts"
    :facebook="writer.facebook"
    :instagram="writer.instagram"
    :twitter="writer.twitter"
    :linkedin="writer.linkedin"
    :github="writer.github"
  ></profil-social-account-modal>
</template>

<script>
import axios from "axios";
import profilInfoModal from "../../components/Modals/profil-info-modal.vue";
import profilDescriptionModal from "../../components/Modals/profil-description-modal.vue";
import profilSocialAccountModal from "../../components/Modals/profil-social-account-modal.vue";
import Alert from "../../components/Modals/Alert.vue";
import session from "../../helpers/session";
export default {
  name: "profilim",
  components: {
    profilInfoModal,
    profilDescriptionModal,
    Alert,
    profilSocialAccountModal,
  },
  data() {
    return {
      alertLevel: "",
      alertText: "",

      reponseWriter: {},
      writer: {
        id: "",
        displayName: "",
        job: "",
        description: "",
        city: "",
        emailAddress: "",
        instagram: "",
        facebook: "",
        twitter: "",
        linkedin: "",
        github: "",
        photoAddress: "",
      },
      articles: [
        {
          publishedDate: "10 Ocak 2021",
          id: 1,
          preViewPhoto:
            "https://miro.medium.com/max/638/1*Dz_mvHp_eQVOvzCPKTP73w.jpeg",
          title: "Döngüler",
          articleLink:
            "https://medium.com/@sergenkahraman/c-d%C3%B6ng%C3%BCler-for-foreach-while-do-while-22c65ddc36c8",
          summary:
            "Birden fazla tekrarlanması gereken işlem/işlemleri gerçekleştirmek için döngü adı verilen yapılar kullanılmaktadır. Döngüler yardımıyla hem tekrarlanması gereken kod bloğunun yazımı kolaylaşır hem de kod okuma işlemi daha basit bir hale getirilmiş olur.C# ortamında 4 farklı döngü kullanılmaktadır. Aşağıda bu döngüler ve değineceğimiz konu başlıkları bulunmaktadır.",
        },
        {
          publishedDate: "05 Mayıs 2021",
          id: 2,
          preViewPhoto:
            "https://miro.medium.com/max/800/1*m0JI8xgF-ZGAvB5GjFNqKg.jpeg",
          title: "Hash Code",
          articleLink:
            "https://medium.com/@sergenkahraman/c-ile-hashcode-ve-gethashcode-46e943876970",
          summary:
            "HashCode , değişken uzunluklu veri kümelerini, sabit uzunluklu veri kümelerine haritalamak amacıyla kullanılan hash algoritması sonucu ortaya çıkan koddur. Bu kavramla ilgili alışılmış bir benzetme vardır o da “HashCode kavramı nesnelerimizin ya da değişkenlerimizin DNA’ sıdır” benzetmesidir. Bu yaklaşımda bir mantık hatası oluşabilir. HashCode kavramı ile ilgili şöyle bir önerme vardır ;",
        },
        {
          publishedDate: "03 Nisan 2021",
          id: 3,
          preViewPhoto:
            "https://miro.medium.com/max/500/1*kMYMdWqdYfN3Bv34-PaiCQ.png",
          title: "İf/Else Yapıları",
          articleLink:
            "https://medium.com/@sergenkahraman/c-kontrol-yap%C4%B1lar%C4%B1-if-else-switch-case-ebf159b7e638",
          summary:
            "Program yazarken bazen koşullar altında gerçekleşmesini istediğiniz durumlar olabilir. İşte bu durumları yönetebilmemiz için Kontrol yapılarını yani IF-ELSE ve SWITCH_CASE deyimlerini kullanmamız gerekir. Aşağıda bu yapılarla ilgili inceleyeceğimiz başlıklar yer almaktadır.",
        },
      ],
    };
  },
  mounted() {
    if (session.isAuthenticated()) {
      this.LoadInfo();
    } else {
      this.$router.push("/writer/yazar-girisi");
    }
  },
  methods: {
    editArticle() {
      console.log("edit butonu unutma!"); //TODO:burası daha yapılmadı
    },
    editInfo() {
      window.$("#profilInfoModal").modal("show");
    },
    editDescription() {
      window.$("#profilDescriptionModal").modal("show");
    },
    editPhoto() {
      console.log("edit butonu unutma!"); //TODO:burası daha yapılmadı
    },
    editSocialAccount() {
      window.$("#profilSocialAccountModal").modal("show");
    },
    LoadInfo() {
      axios
        .get(
          process.env.VUE_APP_API_URL +
            `/Management/Writer/get/${session.getSession().id}`,
          { headers: { Authorization: `Bearer ${session.getSession().token}` } }
        )
        .then((Response) => {
          if (Response.data) {
            this.reponseWriter = Response.data;
            var writer = {
              id: Response.data.id,
              displayName: Response.data.displayName,
              job: Response.data.job,
              description: Response.data.description,
              emailAddress: Response.data.emailAddress,
              city: Response.data.city, //TODO: photoAddress eksik unutma (FTP yi bekliyorum)
              instagram: checkAccount(
                Response.data.socialAccounts,
                "Instagram"
              ),
              facebook: checkAccount(Response.data.socialAccounts, "Facebook"),
              linkedin: checkAccount(Response.data.socialAccounts, "Linkedin"),
              twitter: checkAccount(Response.data.socialAccounts, "Twitter"),
              github: checkAccount(Response.data.socialAccounts, "Github"),
            };
            this.writer = writer;
          }
        });
    },
    saveChangesForSocialAccounts(value) {
      if (value.Facebook) {
        this.refreshResponseWriter(value.Facebook, "Facebook");
      }
      if (value.Instagram) {
        this.refreshResponseWriter(value.Instagram, "Instagram");
      }
      if (value.Twitter) {
        this.refreshResponseWriter(value.Twitter, "Twitter");
      }
      if (value.Linkedin) {
        this.refreshResponseWriter(value.Linkedin, "Linkedin");
      }
      if (value.Github) {
        this.refreshResponseWriter(value.Github, "Github");
      }
      this.Post(this.reponseWriter);
    },
    refreshResponseWriter(value, keyword) {
      var index = this.reponseWriter.socialAccounts.findIndex(
        (x) => x.name == keyword
      );
      if (index > -1) {
        this.reponseWriter.socialAccounts[index].url = value;
      } else {
        var newSocialAccount = { name: keyword, url: value };
        this.reponseWriter.socialAccounts.push(newSocialAccount);
      }
    },
    saveChangesForDescription(value) {
      if (value) {
        this.reponseWriter.description = value;
      }
      this.Post(this.reponseWriter);
    },
    saveChangesForInfo(value) {
      if (value.DisplayName) {
        this.reponseWriter.displayName = value.DisplayName;
      }
      if (value.Job) {
        this.reponseWriter.job = value.Job;
      }
      if (value.City) {
        this.reponseWriter.city = value.City;
      }
      if (value.EmailAddress) {
        this.reponseWriter.emailAddress = value.EmailAddress;
      }
      this.Post(this.reponseWriter);
    },
    Post(data) {
      axios
        .post(
          process.env.VUE_APP_API_URL + "/Management/Writer/update-writer",
          data,
          {
            headers: {
              Authorization: `Bearer ${session.getSession().token}`,
            },
          }
        )
        .then((response) => {
          if (response.data) {
            this.alertLevel = "alert-success";
            this.alertText = "Değişiklikler Başarıyla Kaydedilmiştir.";
            window.$("#alertModal").modal("show");
          }
        });
    },
  },
};
function checkAccount(socialAccounts, account) {
  var result = socialAccounts.find((x) => x.name == account);
  if (result) {
    return result.url;
  }
  return "-";
}
</script>

<style scoped>
.gecici {
  border: solid 1px red;
  min-height: 1000px;
}
.custom-head {
  text-shadow: 0px 0px 2px rgba(0, 0, 0, 0.7);

  font-weight: 600;
}
</style>