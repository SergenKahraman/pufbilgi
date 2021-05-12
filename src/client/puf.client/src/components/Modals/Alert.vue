<template>
  <div
    class="modal fade"
    :id="id"
    tabindex="-1"
    role="dialog"
    :aria-labelledby="id"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Puf Bilgi - Bilgilendirme</h5>
          <button
            type="button"
            class="close"
            data-dismiss="modal"
            aria-label="Close"
          >
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <div v-bind:class="level" class="alert text-center">{{text}}</div>
        </div>
        <div class="modal-footer">
          <button
            type="button"
            class="btn btn-outline-primary"
            data-dismiss="modal"
            @click="ok"
          >
            Tamam
          </button>
          
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "alert",
  props: {
    text: String,
    level: String,
    id:String,
  },
  data() {
    return {
      
    };
  },
  methods:{
    ok(){
      window.location.reload();
    }
  }

};
</script>

<style>
</style>