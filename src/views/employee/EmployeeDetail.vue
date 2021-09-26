<template>
<!-- v-show="isShow" -->
    <div class="dialog"  v-show="isShow" >
        <div class="model" @click="closeDialog"></div>
        <div id="dialog-content" class="dialog-content">
            <div class="dialog-header">
                <div class="dialog-title">THÔNG TIN NHÂN VIÊN
                     <div class="text-khach-hang">  <input type="checkbox" unchecked/> Là khách hàng</div>
                      <div class="text-quan-ly">   <input type="checkbox" unchecked/>Là nhà cung cấp</div>

                </div>
                <div class="cham-hoi-icon"></div>
                <div id="btn-close" @click="closeDialog" class="dialog-close-button">&#x2715;</div>
            </div>
            <div class="dialog-body">
                
                <div class="user-detail">
                    <div class="section section-a">
                       
                        <div class="section-info">
                            <div class="info-feild-ma" 
                            
                                :class="{'invalid': !isValidEmIdentityNumber, 'invalidEmcode': isDuplicatedCode}"
                                style="margin-top: 4px;"
                             >
                                <label for="">Mã(<span style="color: red">*</span>)</label><br>
                                <input id="txtEmCode" type="text" ref="input" v-model="employee.employeeCode" 
                                        @blur="checkEmCode" @focus="isValidEmCode=true"     
                                >
                            </div>
                            <div class="info-feild-ten" 
                              :class="{'invalid': !isValidEmFullName}"
                                style="margin-top: 4px; margin-right: 0px;"
                            >
                                <label for="">Tên(<span style="color: red">*</span>)</label><br>
                                <input id="txtEmName" type="text" v-model="employee.fullName"
                                    @blur="checkEmFullName" @focus="isValidEmFullName=true"
                                >
                            </div>
                            <div class="info-feild-ngay-sinh"
                                :class="{'invalid': !isValidEmFullName}"
                              
                                >
                                <label for="">Ngày sinh</label><br>
                                <input id="txtDateofbirth" type="date" v-if="formMode =='add'" v-model="employee.dateOfBirth">
                                <input type="date" v-else v-model="dobFormat">
                            </div>
                            <div class="info-feild-Gender" 
                            :class="{'invalid': !isValidEmFullName}"
                              >
                                <label for="">Giới tính</label><br>
                                <select id="txtGender" name="" v-model="employee.gender"
                                >
                                    <option value="1">
                                        Nam
                                    </option>
                                    <option value="0">
                                        Nữ
                                    </option>
                                    <option value="2">
                                        Khác 
                                    </option>
                                </select>
                            </div>
                              <div class="info-feild-don-vi"
                              :class="{'invalid': !isValidEmFullName}"
                              >
                               <label for="">Đơn vị(<span style="color: red">*</span>)</label><br>
                                <select id= "txtDonvi" name=""  v-model="employee.departmentId"
                           
                                >
                                    <option value="4e272fc4-7875-78d6-7d32-6a1673ffca7c">
                                        Phòng nhân sự
                                    </option>
                                    <option value="469b3ece-744a-45d5-957d-e8c757976496">
                                        Phòng nghiên cứu 
                                    </option>
                                    <option value="17120d02-6ab5-3e43-18cb-66948daf6128">
                                      Phòng Marketing 
                                    </option>
                                     <option value="142cb08f-7c31-21fa-8e90-67245e8b283e">
                                      Phòng kế toán
                                    </option>
                                    
                                </select>
                            </div>
                            <div class="info-feild-CMND" 
                                :class="{'invalid': !isValidEmIdentityNumber}"
                            >
                                <label for="">Số CMTND/ Căn cước(<span style="color: red">*</span>)</label><br>
                                <input id="txtCMND" type="text" v-model="employee.idCardNumber"
                                  
                                >
                            </div>
                            <div class="info-feild-Ngay-Cap" 
                            
                            >
                                <label for="">Ngày cấp</label><br>
                                <input id="txtNgayCap"  type="date" v-if="formMode=='add'" v-model="employee.idCardDate">
                                <input  type="date" v-else v-model="identidyDateFormat">
                            </div>
                             <div class="info-feild-chuc-danh"
                            :class="{'invalid': !isValidEmFullName}"
                            >
                                <label for="">Chức Danh</label><br>
                                <input  id = "txtChucDanh" type="text" v-model="employee.position">
                            </div>
                            <div class="info-feild-noi-cap"
                             :class="{'invalid': !isValidEmFullName}"
                            >
                                <label for="">Nơi cấp</label><br>
                                <input  id = "txtNoiCap" type="text" v-model="employee.idCardRegion">
                            </div>
                          
                
                        </div>
                    </div>
                   <div class="section section-b">
                           <div class="info-feild-dia-chi"
                             :class="{'invalid': !isValidEmFullName}"
                            >
                                <label for="">Địa chỉ</label><br>
                                <input  id = "txtDiaChi" type="text" v-model="employee.address">
                            </div>

                            
                            <div class="info-feild-di-dong" 
                             :class="{'invalid': !isValidEmIdentityNumber}"
                               
                            >
                                <label for="">DT di động</label><br>
                                <input id="txtDiDong"  type="text" v-model="employee.mobilePhone"
                             
                                >

                            </div>
                             <div class="info-feild-co-dinh" 
                                :class="{'invalid': !isValidEmIdentityNumber,}"
                               
                            >
                                <label for="">DT cố định</label><br>
                                <input id="txtCoDinh"  type="text" v-model="employee.homePhone"
                              
                                >
                            </div>
                            <div class="info-feild-email " 
                                :class="{'invalid': !isValidEmFullName}"
                            >
                                <label for="">Email(<span style="color: red">*</span>)</label><br>
                                <input id="txtEmail" type="text" v-model="employee.email"
                                    @blur="checkEmEmail" @focus="isValidEmEmailEmpty=true; isFormatEmail=true"
                                >
                            </div>
                             <div class="info-feild-bank-account" 
                                :class="{'invalid': !isValidEmIdentityNumber}"
                            >
                                <label for="">Tài khoản ngân hàng</label><br>
                                <input id="txtBankAcc" type="text" v-model="employee.bankAccount"
                                  
                                >
                            </div>
                             <div class="info-feild-ten-bank" 
                                :class="{'invalid': !isValidEmFullName}"
                            
                            >
                                <label for="">Tên ngân hàng</label><br>
                                <input id="txtNameBank" type="text" v-model="employee.bankName"
                                   
                                >
                            </div>
                             <div class="info-feild-chi-nhanh" 
                                :class="{'invalid': !isValidEmFullName}"
                            
                            >
                                <label for="">Chi nhánh</label><br>
                                <input id="txtChiNhanh" type="text" v-model="employee.agency"
                                   
                                >
                            </div>
                       
                    </div> 
                </div>
            </div>
            <div class="dialog-footer">
                <button class="cancel-left" @click="closeDialog"> 
                    Hủy
                </button>
                <button class="btn-default cat-btn" @click="btnSaveClick">
                    Cất
                </button>
                <button id="btn-save" class="btn-default save-btn" @click="btnSaveClick">
                    <i class="far fa-save"></i>
                    Cất và thêm
                </button>
            </div>

        </div>
    </div>
</template>

<script>
import axios from '../../../node_modules/axios'
export default {
    name: 'EmployeeDetail',
    components: {
    },
    data() {
        return {
            isValidEmCode: true,
            isValidEmFullName: true,
            isValidEmIdentityNumber: true,
            isValidEmEmailEmpty: true,
            isValidEmPhoneNumber: true,
            isFormatEmail: true,
            isValidAll : false,
            reg: /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@(([[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,24}))$/
        }
    },
    props:{
        isShow: {type: Boolean, default: false},
        employee: { type: Object, default: null },
        formMode: { type: String, default: "add" },
        isDuplicatedCode: {type: Boolean, default: false},
    },
    methods: {
      closeDialog() {
            this.isValidEmCode= true;
            this.isValidEmFullName= true;
            this.isValidEmIdentityNumber= true;
            this.isValidEmEmailEmpty= true;
             this.isFormatEmail= true;
            this.isValidEmPhoneNumber= true;
           this.isValidAll = false;
          this.$emit('close-dialog');
           
           
        },
        btnSaveClick() {
            // this.checkDuplicatedEmCode(this.employee.mployeeCode);
            // this.checkAll();
     
                if (this.formMode == "add") {
          axios
             .post("https://localhost:44369/api/v1/Employees", this.employee)
          
             .then(() => {
            console.log("ok")
             this.isValidAll = false;
                 this.$emit("close-dialog");
             })
          .catch(() => {
              console.log("Not ok");
             });
                
         
        } else {
          
      //  this.employee.DateOfBirth = this.checkDate(this.employee.dateOfBirth);
        //   this.employee.createdDate = this.checkDate(this.employee.createdDate);
        //    this.employee.idCardDate = this.checkDate(this.employee.idCardDate);
         axios
            .put(
               "https://localhost:44369/api/v1/Employees/" + this.employee.employeeId,
                this.employee
             )
            .then(() => {
                console.log(this.employee)
             this.$emit("close-dialog");
         })
          .catch(() => {
               console.log("not ok");
           });
        }
        
         
            
        },
        checkDate(date) {
            if(!date){
                return null;
            }
            else if(date.length < 10){
                date = date + "T00:00:00";
            }
            return date;
        },
        checkEmCode() {
            if(!this.employee.employeeCode) {
                this.isValidEmCode = false;
            }
            else{
                this.isValidEmCode = true;
            }

        },
        checkEmFullName() {
            if(!this.employee.fullName) {
                this.isValidEmFullName = false;
            }
        },
       
        checkEmIdentityNumber() {
            if(!this.employee.idCardNumber) {
                this.isValidEmIdentityNumber = false;
            }
        },
        checkEmEmail() {
            if(!this.employee.email) {
                this.isValidEmEmailEmpty = false;
            }
            else {
                if(!this.reg.test(String(this.employee.email).toLowerCase())){
                    this.isFormatEmail = false;
                    this.isValidEmEmailEmpty = true;
                }
                else {
                    this.isFormatEmail = true;
                }
            }
        },
        checkEmPhoneNumber() {      // Hàm kiểm tra xem giá trị đã nhập hay không (rỗng hay không)
            if(!this.employee.mobilePhone) {
                this.isValidEmPhoneNumber = false;
            }
        },
        checkAll() {
            this.checkEmCode();
            this.checkEmFullName();
            this.checkEmIdentityNumber();
            this.checkEmEmail();
            this.checkEmPhoneNumber();
            if(this.isValidEmCode && this.isValidEmFullName && 
                this.isValidEmIdentityNumber && this.isValidEmEmailEmpty && this.isValidEmPhoneNumber){
                    this.isValidAll = true;
            }
        },
        changeSalary(e) {
            var temp = e.target.value;
            var checkSalary = Number(temp);
            if(temp || (typeof checkSalary) == 'number') {
                this.employee.Salary = checkSalary;
            }
            else {
                this.employee.Salary = null;
            }
        },
        // checkDuplicatedEmCode(employeeCode) {
            
        // }
    },
    computed: {
        dobFormat: {    // giá trị địng dạng ngày sinh
            get: function () {
                var date = this.employee.dateOfBirth;
                var res = '';
                if(!date) {
                    return '';
                }
                for(let i = 0; i < 10; i++){
                    res += date[i];
                }
                return res;
            },
            
            set: function (newValue) {
                this.employee.dateOfBirth = newValue
            }
        },
        joinDateFormat: {       // giá trị địng dạng ngày tham gia
            get: function () {
                var date = this.employee.createdDate;
                var res = '';
                if(!date) {
                    return '';
                }
                for(let i = 0; i < 10; i++){
                    res += date[i];
                }
                return res;
            },
            
            set: function (newValue) {
                this.employee.JoinDate = newValue
            }
        },
        identidyDateFormat: {       // giá trị địng dạng ngày cấp
            get: function () {
                var date = this.employee.idCardDate;
                var res = '';
                if(!date) {
                    return '';
                }
                for(let i = 0; i < 10; i++){
                    res += date[i];
                }
                return res;
            },
            
            set: function (newValue) {
                this.employee.idCardDate = newValue
            }
        },
        formatSalary: function() {      // giá trị địng dạng tiền
            var salary = this.employee.Salary;
            if(!salary) {
                return '';
            }
            var moneyFormat = salary.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.');
            return moneyFormat;
        }
    }
}
</script>

<style scoped>
.text-khach-hang{
   font-size: 16px;
    width: 164px;
    position: absolute;
    top: 25px;
    left: 23%;
    padding-left: 0;
}
.text-quan-ly{
    font-size: 16px;
    width: 164px;
    position: absolute;
    top: 25px;
    left: 36%;
    padding-left: 0;
}
.cham-hoi-icon{
    width: 22px;
	height: 22px;
    background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -201px -33px;
     text-align: center;
    line-height: 40px;
    font-size: 20px;
    position: absolute;
    right: 33px;
    top: 8px;
    width: 40px;
    height: 40px;
    border-radius: 0 4px 0 4px;
   cursor: pointer;
}
</style>