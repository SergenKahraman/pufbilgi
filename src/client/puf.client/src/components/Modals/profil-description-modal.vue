<template>
  <div
    class="modal fade"
    id="profilDescriptionModal"
    tabindex="-1"
    role="dialog"
    aria-labelledby="profilDescriptionModalTitle"
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
            <label for="descriptionOld" class="col-form-label">Açıklama - Şimdiki</label>
            <textarea
              :placeholder="description"
              type="text"
              class="form-control"
              id="descriptionOld"
              disabled
            />
          </div>
          <div class="form-group">
            <label for="description" class="col-form-label">Açıklama - Yeni</label>
            <textarea
              
              v-model="Description"
              type="text"
              class="form-control"
              id="description"
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
  name: "profil-description-modal",
  props: {
    description: String,
  },
  data() {
    return {
      Description:"",
    };
  },

  methods: {
    SaveChanges() {
      this.$emit("clicked", this.Description);
      this.Description = "";
      window.$("#profilDescriptionModal").modal("hide");
    },
    Cancel() {
      this.Description = "";
    },
  },
};
</script>

<style>
</style>