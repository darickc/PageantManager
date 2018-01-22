webpackJsonp(["admin.module"],{

/***/ "../../../../../src/app/admin/admin.component.html":
/***/ (function(module, exports) {

module.exports = "<p>\n  admin works!\n</p>\n<a routerLink=\"pageants\">Manage Pageants</a>\n"

/***/ }),

/***/ "../../../../../src/app/admin/admin.component.scss":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/admin/admin.component.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/esm5/core.js");
var AdminComponent = /** @class */ (function () {
    function AdminComponent() {
    }
    AdminComponent.prototype.ngOnInit = function () {
    };
    AdminComponent = __decorate([
        core_1.Component({
            selector: 'app-admin',
            template: __webpack_require__("../../../../../src/app/admin/admin.component.html"),
            styles: [__webpack_require__("../../../../../src/app/admin/admin.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], AdminComponent);
    return AdminComponent;
}());
exports.AdminComponent = AdminComponent;


/***/ }),

/***/ "../../../../../src/app/admin/admin.module.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/esm5/core.js");
var router_1 = __webpack_require__("../../../router/esm5/router.js");
var shared_module_1 = __webpack_require__("../../../../../src/app/shared/shared.module.ts");
var admin_component_1 = __webpack_require__("../../../../../src/app/admin/admin.component.ts");
var pageants_component_1 = __webpack_require__("../../../../../src/app/admin/pageants/pageants.component.ts");
var routes = [
    {
        path: '',
        children: [
            {
                path: '',
                component: admin_component_1.AdminComponent,
                data: { title: 'Admin' }
            },
            {
                path: 'pageants',
                component: pageants_component_1.PageantsComponent,
                data: { title: 'Pageants' }
            }
        ]
    }
];
var AdminModule = /** @class */ (function () {
    function AdminModule() {
    }
    AdminModule = __decorate([
        core_1.NgModule({
            imports: [
                router_1.RouterModule.forChild(routes),
                shared_module_1.SharedModule,
            ],
            declarations: [admin_component_1.AdminComponent, pageants_component_1.PageantsComponent],
            exports: [router_1.RouterModule]
        })
    ], AdminModule);
    return AdminModule;
}());
exports.AdminModule = AdminModule;


/***/ }),

/***/ "../../../../../src/app/admin/pageants/pageants.component.html":
/***/ (function(module, exports) {

module.exports = "<p>\n  pageants works!\n</p>\n"

/***/ }),

/***/ "../../../../../src/app/admin/pageants/pageants.component.scss":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/admin/pageants/pageants.component.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/esm5/core.js");
var PageantsComponent = /** @class */ (function () {
    function PageantsComponent() {
    }
    PageantsComponent.prototype.ngOnInit = function () {
    };
    PageantsComponent = __decorate([
        core_1.Component({
            selector: 'app-pageants',
            template: __webpack_require__("../../../../../src/app/admin/pageants/pageants.component.html"),
            styles: [__webpack_require__("../../../../../src/app/admin/pageants/pageants.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], PageantsComponent);
    return PageantsComponent;
}());
exports.PageantsComponent = PageantsComponent;


/***/ })

});
//# sourceMappingURL=admin.module.chunk.js.map