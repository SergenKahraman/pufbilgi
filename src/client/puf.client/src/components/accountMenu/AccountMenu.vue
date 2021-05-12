<template>
  <header class="header">
    <nav class="header__nav">
      <ul class="header__navbar">
        <li class="header__item">
          <a href="#" class="header__link">
            <transition name="slide-fade">
              <!-- Header Navigation Menu Icons -->
              <button
                class="header--button"
                v-if="show"
                key="on"
                @click="show = false"
              >
                <svg viewBox="0 0 24 24" class="header--icon">
                  <title>Close</title>
                  <path d="M0 0h24v24H0V0z" fill="none" />
                  <path
                    fill="currentColor"
                    d="M18.3 5.71c-.39-.39-1.02-.39-1.41 0L12 10.59 7.11 5.7c-.39-.39-1.02-.39-1.41 0-.39.39-.39 1.02 0 1.41L10.59 12 5.7 16.89c-.39.39-.39 1.02 0 1.41.39.39 1.02.39 1.41 0L12 13.41l4.89 4.89c.39.39 1.02.39 1.41 0 .39-.39.39-1.02 0-1.41L13.41 12l4.89-4.89c.38-.38.38-1.02 0-1.4z"
                  />
                </svg>
              </button>
              <button
                class="header--button"
                v-else
                key="off"
                @click="show = true"
              >
                <svg viewBox="0 0 24 24" class="header--icon">
                  <title>Navigation Menu</title>
                  <path
                    fill="currentColor"
                    d="M6,8c1.1,0 2,-0.9 2,-2s-0.9,-2 -2,-2 -2,0.9 -2,2 0.9,2 2,2zM12,20c1.1,0 2,-0.9 2,-2s-0.9,-2 -2,-2 -2,0.9 -2,2 0.9,2 2,2zM6,20c1.1,0 2,-0.9 2,-2s-0.9,-2 -2,-2 -2,0.9 -2,2 0.9,2 2,2zM6,14c1.1,0 2,-0.9 2,-2s-0.9,-2 -2,-2 -2,0.9 -2,2 0.9,2 2,2zM12,14c1.1,0 2,-0.9 2,-2s-0.9,-2 -2,-2 -2,0.9 -2,2 0.9,2 2,2zM16,6c0,1.1 0.9,2 2,2s2,-0.9 2,-2 -0.9,-2 -2,-2 -2,0.9 -2,2zM12,8c1.1,0 2,-0.9 2,-2s-0.9,-2 -2,-2 -2,0.9 -2,2 0.9,2 2,2zM18,14c1.1,0 2,-0.9 2,-2s-0.9,-2 -2,-2 -2,0.9 -2,2 0.9,2 2,2zM18,20c1.1,0 2,-0.9 2,-2s-0.9,-2 -2,-2 -2,0.9 -2,2 0.9,2 2,2z"
                  />
                </svg>
              </button>
            </transition>
          </a>
          <!-- Dropdown Menu -->
          <transition name="dropdown">
            <div
              class="dropdown__menu"
              v-bind:class="{ active: show }"
              v-if="show"
            >
              <ul class="dropdown__menu-nav">
                <li class="dropdown__menu-item">
                  <a href="/writer/profilim" class="dropdown__menu-link" title="Account">
                    <div class="dropdown__menu-svg">
                      <i class="fas fa-user-circle fa-2x"></i>
                    </div>
                    <div class="dropdown__menu-text">Profilim</div>
                  </a>
                </li>
                <li class="dropdown__menu-item">
                  <a href="#" class="dropdown__menu-link" title="Personal info">
                    <div class="dropdown__menu-svg">
                      <i class="fas fa-plus-circle fa-2x"></i>
                    </div>
                    <div class="dropdown__menu-text">Yazı Ekle</div>
                  </a>
                </li>
                <li class="dropdown__menu-item">
                  <a
                    href="#"
                    class="dropdown__menu-link"
                    title="Personal info"
                    @click="logout"
                  >
                    <div
                      class="dropdown__menu-svg"
                      style="margin-left: -2px !important"
                    >
                      <i class="fas fa-door-open fa-2x"></i>
                    </div>
                    <div
                      class="dropdown__menu-text text-danger"
                      style="margin-left: 18px !important"
                    >
                      Çıkış Yap
                    </div>
                  </a>
                </li>

                <!-- Dropdown Menu Separator -->
                <hr />
                <li class="dropdown__menu-item">
                  <a href="#" class="dropdown__menu-link" title="Help">
                    <div class="dropdown__menu-svg">
                      <svg viewBox="0 0 512 512">
                        <path
                          fill="currentColor"
                          d="M256 340c-15.464 0-28 12.536-28 28s12.536 28 28 28 28-12.536 28-28-12.536-28-28-28zm7.67-24h-16c-6.627 0-12-5.373-12-12v-.381c0-70.343 77.44-63.619 77.44-107.408 0-20.016-17.761-40.211-57.44-40.211-29.144 0-44.265 9.649-59.211 28.692-3.908 4.98-11.054 5.995-16.248 2.376l-13.134-9.15c-5.625-3.919-6.86-11.771-2.645-17.177C185.658 133.514 210.842 116 255.67 116c52.32 0 97.44 29.751 97.44 80.211 0 67.414-77.44 63.849-77.44 107.408V304c0 6.627-5.373 12-12 12zM256 40c118.621 0 216 96.075 216 216 0 119.291-96.61 216-216 216-119.244 0-216-96.562-216-216 0-119.203 96.602-216 216-216m0-32C119.043 8 8 119.083 8 256c0 136.997 111.043 248 248 248s248-111.003 248-248C504 119.083 392.957 8 256 8z"
                        />
                      </svg>
                    </div>
                    <div class="dropdown__menu-text">Help</div>
                  </a>
                </li>
                <li class="dropdown__menu-item">
                  <a href="#" class="dropdown__menu-link" title="Send feedback">
                    <div class="dropdown__menu-svg">
                      <svg viewBox="0 0 512 512">
                        <path
                          fill="currentColor"
                          d="M448 0H64C28.7 0 0 28.7 0 64v288c0 35.3 28.7 64 64 64h96v84c0 7.1 5.8 12 12 12 2.4 0 4.9-.7 7.1-2.4L304 416h144c35.3 0 64-28.7 64-64V64c0-35.3-28.7-64-64-64zm32 352c0 17.6-14.4 32-32 32H293.3l-8.5 6.4L192 460v-76H64c-17.6 0-32-14.4-32-32V64c0-17.6 14.4-32 32-32h384c17.6 0 32 14.4 32 32v288zm-224-88c-13.3 0-24 10.7-24 24s10.7 24 24 24 24-10.7 24-24-10.7-24-24-24zm-8.5-24h17c4.2 0 7.7-3.3 8-7.5l7-112c.3-4.6-3.4-8.5-8-8.5h-31c-4.6 0-8.3 3.9-8 8.5l7 112c.3 4.2 3.8 7.5 8 7.5z"
                        />
                      </svg>
                    </div>
                    <div class="dropdown__menu-text">Send feedback</div>
                  </a>
                </li>
              </ul>
            </div>
          </transition>
        </li>
      </ul>
    </nav>
  </header>
</template>

<script>
export default {
  name: "AccountMenu",
  data(){
    return{
      show:false,
    }
  },
  methods:{
    logout(){
      window.localStorage.removeItem("s");
      this.session = false;
      location.reload();
      this.show = false;
    }
  }
};
</script>

<style>
</style>