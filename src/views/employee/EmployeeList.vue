<template>
    <div>
        <div class="page-title">
            <div class="page-left"> Danh sách nhân viên</div>
            <div class="page-right">
                <button id="btn-add" class="btn-default add-employee-btn" @click="addBtnClick">
                    Thêm mới nhân viên
                </button>
            </div>
        </div>
        <div class="toolbar">
            <input type="text" class="input-search" 
            @click="searchData"
            placeholder="Tìm kiếm theo Mã, tên nhân viên" 
            v-model="search"

            />
            
            <button class="btn-refresh" @click="loadData"></button>
            <!-- <button class="btn-delete" @click="deleteBtnClick">Xóa nhân viên</button> -->
        </div>

        <div class="grid">
            <table id="tblClassListCustomer" class="table" width="100%" border="0">
                <thead>
                    <tr>
                        <th style="width: 2%"><input type="checkbox" unchecked> </th>
                        <th style="width: 8.5%">MÃ NHÂN VIÊN</th>
                        <th style="width: 9%">TÊN NHÂN VIÊN</th>
                        <th style="width: 6%">GIỚI TÍNH</th>
                        <th style="width: 8%">NGÀY SINH </th>
                        <th style="width: 6%">SỐ CMND</th>
                        <th style="width: 12%">CHỨC DANH</th>
                        <th style="width: 10%">TÊN ĐƠN VỊ</th>
                        <th style="width: 12%">SỐ TÀI KHOẢN</th>
                        <th style="width: 10%">TÊN NGÂN HÀNG</th>
                        <th style="width: 10%">CHI NHÁNH NGÂN HÀNG</th>
                        <th style="width: 6%">CHƯC NĂNG</th>
                    </tr>
                </thead>
                <tbody>
                     <tr
                     v-for="employee in employees" :key="employee.employeeId" 
                            :employee="employee" 
                            @dblclick="trDblClick(employee.employeeId)"
                             @click="trClick(employee.employeeId)"
                           
                     >
                        <td style="width: 2%"><input type="checkbox" unchecked> </td>
                        <td style="9%">{{employee.employeeCode}}</td>
                        <td style="width: 9%">{{employee.fullName}}</td>
                        <td style="width: 6%">{{formatGender(employee.gender)}}</td>
                        <td style="width: 8%">{{ formatDate(employee.dateOfBirth) }}</td>
                        <td style="width: 6%">{{employee.idCardNumber}}</td>
                       <td style="width: 12%">{{employee.position}}</td>
                        <td style="width: 10%">{{checkDonVi(employee.departmentId)}}</td>
                        <td style="width: 12%">{{employee.bankAccount}}</td>
                        <td style="width: 12%">{{employee.bankName}}</td>
                        <td style="width: 10%">{{employee.agency}}</td>
                        <td style="width: 6%">
                            <div class="thang-bo">
                               <div class="left-box-drop">
                                   {{formatChoice(choice)}}
                               </div>
                             <select id="choice-select"
                             class="drop-down-default department-drop-down"
                             @change="deleteData"
                             v-model="choice"
                            >
                            <option value="allChoice"></option>
                            <option value="0" >Nhân bản</option>
                            <option value="1">Xóa</option>
                            <option value="2">Sửa</option>
                            <option value="3">Ngừng sử dụng</option>
                             </select>
                             </div>
                        </td>
                    </tr>
                    <!-- <EmployeeItem v-for="(employee, index) in employees" 
                            :key="employee.id" 
                            :employee="employee" 
                            @trDblClick="trDblClick(employee.id)"
                            @trClick="trClick(employee.id,index)"
                            :class="{ 'bg-row-selected': activeIndex === index}"
                    /> -->
                </tbody>
            </table>
            <EmployeeDetail 
                :isShow="isShowDialogDetail" 
                :employee="selectedEmployee"
                :formMode="dialogFormMode"
                @check-duplicated-em-code="checkDuplicatedEmCode"
                @close-dialog="closeDialog" 
                :isDuplicatedCode="isDuplicated"
                
            />
            <DialogDelete
                :selectedEmployeeDelete="selectedEmployee"
                :isShow="isShowDialogDelete"
                @close-dialog="closeDialog"
                @confirm-delete="confirmDelete" 
             />
        </div>
    </div>
</template>

<script>
import EmployeeDetail from './EmployeeDetail.vue'
// import EmployeeItem from './EmployeeItem.vue'
import DialogDelete from './DialogDelete.vue'
import axios from 'axios'
import $ from 'jquery'

export default {
    components: {
        EmployeeDetail,
        // EmployeeItem,
        DialogDelete
    },
    created() {

        //load du lieu 
        axios.get("https://localhost:44369/api/v1/Employees")
       
            .then(res => {
                //giong nhu done trong jquerry
                // console.log(res);
                 this.employees = res.data;
                this.employeesRoot = res.data;
                this.employees = this.employeesRoot;
            })
            .catch(res => {
                console.log(res);
            })
    },
    props: [],
    data() {
        return {
            maxEmployyCode: -1,
            dialogFormMode: "add",
            isShowDialogDetail: false,
            isShowDialogDelete: false,
            selectedEmployee: {},
            employees: [],
            employeesRoot:[],
            activeIndex: null,
            isConfirmDelete: false,
            isDuplicated: false,
            departmentSelectValue: null,
            search:null,
           
        }
    },
    methods: {
        loadData() {
            axios.get("https://localhost:44369/api/v1/Employees")
          
            .then(res => {
                this.employeesRoot = res.data;
                this.employees = this.employeesRoot;
            })
            .catch(res => {
                console.log(res);
            })
        },
          searchData() {
               axios.get("https://localhost:44369/api/v1/searchs/search?m_input=" +this.search)
          
            .then(res => {
                this.employees = res.data;
                this.employeesRoot = res.data;
                this.employees = this.employeesRoot;
                console.log(res);
            })
            .catch(res => {
                console.log(res);
            })
        }
        ,
        addBtnClick() {
            $(document).ready(function () {
                $('#txtEmCode').first().focus();
            });
            
             //this.selectedEmployee = {};
            // this.selectedEmployee.employeeCode = 'NV-' + this.findMaxEmployeeCode() + 1;
           // this.selectedEmployee.employeeCode = this.getNewEmployeeCode();

            // axios.get("https://localhost:44369/api/v1/Employees/" +this.employees.employeeId)
            // .then(res => {
            //     this.selectedEmployee = {};
            //     var newCode = res.data;
            //     this.selectedEmployee.employeeCode = newCode;
            // })
            // .catch(res => {
            //     console.log(res);se
            // })
            this.selectedEmployee = {};
            this.isShowDialogDetail = true;
            this.dialogFormMode = "add";
        },
        closeDialog() {
            this.isShowDialogDetail = false;
            this.isShowDialogDelete = false;
            if(this.dialogFormMode == 'add') {
                this.selectedEmployee = {};
            }
            this.loadData();
        },
        trDblClick(employeeId){
            //lay id cua ban ghi duoc chon

            //goi API lay thong tin

            //thuc hien bindding du lieu len form chi tiet 

            //hieen thi form chi tiet
            $(document).ready(function () {
                $('#txtEmCode').first().focus();
            });
            axios.get("https://localhost:44369/api/v1/Employees/" + employeeId)
            // axios.get("http://localhost:3000/employees/" + EmployeeId)
            .then(res => {
                this.selectedEmployee = res.data;
               
                // this.selectedEmployee.DateOfBirth = this.formatInputDate(this.selectedEmployee.DateOfBirth);
                // this.selectedEmployee.IdentityDate = this.formatInputDate(this.selectedEmployee.IdentityDate);
                // this.selectedEmployee.JoinDate = this.formatInputDate(this.selectedEmployee.JoinDate);
                
            })
            .catch(res => {
                console.log(res);
            });
            this.isShowDialogDetail = true;
            this.dialogFormMode = "edit";
        },
        trClick(employeeId) {
         
            axios.get("https://localhost:44369/api/v1/Employees/" + employeeId)
            // axios.get("http://localhost:3000/employees/" + EmployeeId)
            .then(res => {
                this.selectedEmployee = res.data;
            
            })
            .catch(res => {
                console.log(res);
            });
        },
        deleteBtnClick() {
            // var result = confirm('Chắc chưa??');
            this.isShowDialogDelete = true;
        },
        formatInputDate(date) {
            if(!date) return null;
            return date.slice(0,10);
        },
        confirmDelete() {
            this.isConfirmDelete = true;
            if(this.isConfirmDelete) {
                axios.delete("https://localhost:44369/api/v1/Employees/" + this.selectedEmployee.employeeId)
                // axios.delete("http://localhost:3000/employees/" + this.selectedEmployee.id)
                .then( ( )=> {
                    // console.log(res);
                    this.loadData();
                    this.isShowDialogDelete = false;
                })
                .catch(res => {
                    console.log(res);
                });
            }
        },
        findMaxEmployeeCode() {
            var max = -999;
            var employeesTmp = this.employees
            employeesTmp.forEach(employee => {
                employee.employeeCode = employee.employeeCode.toLowerCase();
            });
            employeesTmp = employeesTmp.filter(employee => {
                return employee.employeeCode.includes('NV-') == true;
            });
            employeesTmp.forEach(employee => {
                employee.employeeCode = Number(employee.employeeCode.slice(4));
                max = employee.employeeCode > max ? employee.employeeCode : max;
            });
            return max;
        },
        checkDuplicatedEmCode(employeeCode) {
            var check = this.employees.some(employee => {
                return employee.employeeCode == employeeCode;
            })
            if(check) {
                this.isDuplicated = true;
            }
            else {
                this.isDuplicated = false;
            }
        },
        deleteData(){
            this.isShowDialogDelete = true;
            //  var selectDepartmentValue = $('#department-select option').filter(':selected').val();
            // var selectPositionValue = $('#position-select option').filter(':selected').val();
            // console.log(selectPositionValue);
            
            // console.log(selectDepartmentValue)
            // console.log(this.employeesRoot)
            // var employeesRoot = this.loadData();
 
         
       
        //         this.employees = this.employeesRoot.filter(employee => {
        //             return employee.DepartmentId == selectDepartmentValue;
        //         })
        //     }
        //     else if(selectDepartmentValue == 'allDepartment' && selectPositionValue != 'allPosition') {
        //         this.employees = this.employeesRoot.filter(employee => {
        //             return employee.PositionId == selectPositionValue;
        //         })
        //     }
        //     else if(selectDepartmentValue != 'allDepartment' && selectPositionValue != 'allPosition'){
        //         this.employees = this.employeesRoot.filter(employee => {
        //             return employee.DepartmentId == selectDepartmentValue;
        //         }).filter(employee => {
        //             return employee.PositionId == selectPositionValue;
        //         })
        //         // console.log(this.employees);
        //     }
        //     else {
        //         this.loadData();
        //     }
        //     // console.log(this.employees);
        // },
        // filterPosition() {
        //     var selectPositionValue = $('#position-select option').filter(':selected').val();
        //     console.log(selectPositionValue);
        // }
        // trBlur() {
        //     $('.bg-row-selected').removeClass('bg-row-selected');
        //     this.selectedEmployee = null;
        // }}
        
        },
        formatDate(date){
            if(!date) {
                return "";
            }
            var newDate = new Date(date);
            var dateString = newDate.getDate();
            if(dateString < 10) {
                dateString = "0" + dateString;
            }
            var monthString = newDate.getMonth() + 1;
            if(monthString < 10) {
                monthString = "0" + monthString;
            }
            var yearString = newDate.getFullYear();
            return `${dateString}/${monthString}/${yearString}`;
        },
        formatGender(gender){
            if(gender != null){
                if(gender == 1){
                    return "Nam";
                }else if(gender == 0){
                    return "nữ";
                }else{return "khác";}
            }
        },
         formatChoice(gender){
            if(gender != null){
                if(gender == 1){
                    return "Xóa";
                }else if(gender == 0){
                    return "Nhân bản";
                }else if(gender == 0){
                    return "Sửa";}
                else{return "Ngừng SD";}
            }
        },
         checkDonVi:function(departmentId) {
            if(departmentId!=null) {
                if(departmentId == "4e272fc4-7875-78d6-7d32-6a1673ffca7c"){
                    return "Phòng nhân sự";
                }
                else if(departmentId == "469b3ece-744a-45d5-957d-e8c757976496"){
                    return "Phòng nghiên cứu ";
                }
                else if(departmentId =="17120d02-6ab5-3e43-18cb-66948daf6128"){
                    return "Phòng Marketing ";
                }
                else{
                    return " Phòng kế toán ";
                }
            }
        },

    },
    watch: {
        
    }
}
</script>

<style scoped>
.page-title {
  height: 40px;
  display: flex;
  align-items: center;
 
}

.page-title .page-right {
  position: absolute;
  right: 24px;
}

.page-title .page-left {
  font-size: 24px;
  font-weight: bold;
}

.toolbar {
  margin-top: 12px;
  display: flex;
  width: 100%;
  align-items: center;
  height: 51px;
  background-color: white;
  border-radius: 1px;
  border-bottom: 1px solid #bbb;
}

.grid {
  position: absolute;
  right: 24px;
  left: 24px;
  bottom: 60px;
  top: 128px;
  overflow-y: auto;
  background-color: rgb(255, 251, 251);
}

.grid::-webkit-scrollbar {
  display: none;
}

/* Hide scrollbar for IE, Edge and Firefox */
.grid {
  -ms-overflow-style: none;  /* IE and Edge */
  scrollbar-width: none;  /* Firefox */
}

.bg-row-selected {
    background-color: #E5E5E5;
} 

.add-employee-btn {
    background-image: url('../../assets/icon/add.png');
    background-repeat: no-repeat;
    background-position-y:center;
    background-position-x: 16px;
    background-size: 16px;
    padding-left: 36px;
    padding-right: 16px;
}
.input-search{
    position: absolute;
    width: 260px; 
    font-size: 13px;
    right: 80px;
}

</style>



