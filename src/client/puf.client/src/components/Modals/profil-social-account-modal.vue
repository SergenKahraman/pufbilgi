<template>
  <div
    class="modal fade"
    id="profilSocialAccountModal"
    tabindex="-1"
    role="dialog"
    aria-labelledby="profilSocialAccountModalTitle"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <p class="modal-title text-muted">Değiştirmek istemediğiniz bölümleri boş bırakın.</p>
          <button
            type="button"
            class="close"
            data-dismiss="modal"
            aria-label="Close"
            @click="Cancel"
          >
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <div class="form-group">
            <label for="facebook" class="col-form-label">Facebook</label>
            <input
              :placeholder="facebook"
              v-model="newWriter.Facebook"
              type="text"
              class="form-control"
              id="facebook"
            />
          </div>
          <div class="form-group">
            <label for="instagram" class="col-form-label">Instagram</label>
            <input
              :placeholder="instagram"
              v-model="newWriter.Instagram"
              type="text"
              class="form-control"
              id="instagram"
            />
          </div>
          <div class="form-group">
            <label for="twitter" class="col-form-label">Twitter</label>
            <input
              :placeholder="twitter"
              v-model="newWriter.Twitter"
              type="text"
              class="form-control"
              id="twitter"
            />
          </div>
          <div class="form-group">
            <label for="linkedin" class="col-form-label">Linkedin</label>
            <input
              :placeholder="linkedin"
              v-model="newWriter.Linkedin"
              type="text"
              class="form-control"
              id="linkedin"
            />
          </div>
          <div class="form-group">
            <label for="github" class="col-form-label">Github</label>
            <input
              :placeholder="github"
              v-model="newWriter.Github"
              type="text"
              class="form-control"
              id="github"
            />
          </div>
        </div>
        <div class="modal-footer">
          <button
            type="button"
            class="btn btn-outline-danger"
            data-dismiss="modal"
            @click="Cancel"
          >
            İptal
          </button>
          <button
            @click="SaveChanges"
            type="button"
            class="btn btn-outline-primary"
          >
            Değişiklikleri Kaydet
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "profil-social-account-modal",
  props: {
    instagram: String,
    facebook: String,
    twitter: String,
    linkedin: String,
    github: String,
  },
  data() {
    return {
      newWriter: {
        Instagram: "",
        Facebook: "",
        Twitter: "",
        Linkedin:"",
        Github:"",
      },
    };
  },

  methods: {
    SaveChanges() {
      this.$emit("clicked", this.newWriter);
      this.newWriter.Instagram = "";
      this.newWriter.Facebook = "";
      this.newWriter.Twitter = "";
      this.newWriter.Linkedin = "";
      this.newWriter.Github = "";
      window.$("#profilSocialAccountModal").modal("hide");
    },
    Cancel() {
      this.newWriter.Instagram = "";
      this.newWriter.Facebook = "";
      this.newWriter.Twitter = "";
      this.newWriter.Linkedin = "";
      this.newWriter.Github = "";
    },
  },
};
</script>

<style>
</style>