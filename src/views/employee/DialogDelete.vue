<template>
    <div class="dialog-delete"  v-show="isShow">
        <div class="model" @click="closeDialog"></div>
        <div class="dialog-delete-content">
            <div class="dialog-delete-header">
                <div class="dialog-delete-title">XÁC NHẬN</div>
                <div id="btn-close" @click="closeDialog" class="dialog-delete-close-button">&#x2715;</div>
            </div>
            <div class="dialog-delete-body">
                <div class="img-wrapper">
                    <img src="../../assets/icon/delete-warning-icon.png" alt="delete-icon">
                </div>
                <div v-if="selectedEmployeeDelete.employeeCode" class="text-confirm">
                    Bạn có chắc chắn muốn xóa nhân viên có mã <br> <b>{{selectedEmployeeDelete.employeeCode}}</b> không?
                </div>
                <div v-else class="text-confirm">
                    Hãy chọn nhân viên để xóa!!
                </div>
            </div>
            <div class="dialog-delete-footer">
                <button class="btn-default cancel-btn" @click="closeDialog">
                    <b>CANCEL</b>
                </button>
                <button id="btn-save" class="btn-default confirm-btn" @click="btnConfirmClick">
                    <b>DELETE</b>
                </button>
            </div>
        </div>
            
    </div>
</template>

<script>
export default {
    name: 'DialogDelete',
    components: {
    },
    props:{
        isShow: {type: Boolean, default: false},
        selectedEmployeeDelete: {type: Object, default: null},
    },
    methods: {
        closeDialog() {
            this.$emit('close-dialog')
        },
        btnConfirmClick() {
            this.$emit('confirm-delete');
        }
    },
}
</script>

<style scoped>
.dialog-delete .model{
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
    bottom:0;
    background-color: #000000;
    opacity:.4;
}

    .dialog-delete .dialog-delete-content {
        padding: 24px;
        position: fixed;
        top: calc(50% - 150px);
        left: calc(50% - 227px);
        width: 454px;
        height: 180px;
        border-radius: 4px;
        background-color: #ffffff;
    }

    .dialog-delete .dialog-delete-title{
        font-size: 20px;
        font-weight: bold;
    }

    .dialog-delete .dialog-delete-close-button {
        text-align: center;
        line-height: 40px;
        font-size: 20px;
        position: absolute;
        right: 0;
        top: 0;
        width: 40px;
        height: 40px;
        border-radius: 0 4px 0 4px;
    }

    .dialog-delete .dialog-delete-close-button:hover{
        background-color:#bbb;
        cursor: pointer;
    }

    .dialog-delete .dialog-delete-body {
        display: flex;
        margin-top: 20px;
    }

    .dialog-delete-body .img-wrapper {
        height: 36px;
        width: 36px;
        background-color: #bbb;
        border-radius: 50%;
        display: flex;
    }

    .dialog-delete-body .img-wrapper img {
        margin: auto;
    }

    .dialog-delete-body .text-confirm {
        margin-left: 10px;
        font-size: 18px;
        line-height: 36px;
    }

    .dialog-delete .dialog-delete-footer {
        width: calc(100%);
        background-color: #e5e5e5;
        height: 55px;
        display: flex;
        justify-content: flex-end;
        align-items: center;
        position: absolute;
        bottom: 0;
        margin-left: -24px;
        border-bottom-right-radius: 4px;
        border-bottom-left-radius: 4px;
    }

        .dialog-delete .dialog-delete-footer .save-btn {
            height: 40px;
            margin-left: 20px;
            margin-right: 20px;
        }

        .dialog-delete .dialog-delete-footer .cancel-btn {
            background-color: transparent;
            color: #000
        }

        .dialog-delete .dialog-delete-footer .cancel-btn:hover {
            background-color: #bbb;
        }
    .confirm-btn {
        background-color: #F65454;
        margin-right: 20px;
        margin-left: 16px;
    }

    .confirm-btn:hover {
        background-color: #ec1414;
    }

</style>