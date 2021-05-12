<template>
  <div
    class="modal fade"
    id="profilInfoModal"
    tabindex="-1"
    role="dialog"
    aria-labelledby="profilInfoModalTitle"
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
            <label for="displayname" class="col-form-label">Adı Soyadı</label>
            <input
              :placeholder="displayName"
              v-model="newWriter.DisplayName"
              type="text"
              class="form-control"
              id="displayname"
            />
          </div>
          <div class="form-group">
            <label for="emailAddress" class="col-form-label">Email</label>
            <input
              :placeholder="emailAddress"
              v-model="newWriter.EmailAddress"
              type="text"
              class="form-control"
              id="emailAddress"
            />
          </div>
          <div class="form-group">
            <label for="job" class="col-form-label">Meslek</label>
            <input
              :placeholder="job"
              v-model="newWriter.Job"
              type="text"
              class="form-control"
              id="job"
            />
          </div>
          <div class="form-group">
            <label for="city" class="col-form-label">Şehir</label>
            <input
              :placeholder="city"
              v-model="newWriter.City"
              type="text"
              class="form-control"
              id="city"
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
  name: "profil-info-modal",
  props: {
    displayName: String,
    emailAddress: String,
    job: String,
    city: String,
  },
  data() {
    return {
      newWriter: {
        DisplayName: "",
        EmailAddress: "",
        Job: "",
        City:""
      },
    };
  },

  methods: {
    SaveChanges() {
      this.$emit("clicked", this.newWriter);
      this.newWriter.DisplayName = "";
      this.newWriter.EmailAddress = "";
      this.newWriter.Job = "";
      this.newWriter.City = "";
      window.$("#profilInfoModal").modal("hide");
    },
    Cancel() {
      this.newWriter.DisplayName = "";
      this.newWriter.EmailAddress = "";
      this.newWriter.Job = "";
      this.newWriter.City = "";
    },
  },
};
</script>

<style>
</style>