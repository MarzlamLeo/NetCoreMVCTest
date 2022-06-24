using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreMVCTest.Dto;
using NetCoreMVCTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace NetCoreMVCTest.Controllers
{
    public class UserController : Controller
    {
        private TestDbContext _context;

        public UserController(TestDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/

        //当项目启动时，解决修改视图，不能立马生效问题？
        //Nuget引入：Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
        //在startup下的ConfigureServices方法中添加services.AddRazorPages().AddRazorRuntimeCompilation();

        //登录页面
        public IActionResult Login()
        {

            return View();
        }

        //登录验证
        public IActionResult CheckLogin(LoginDto dto)
        {
            var rtn = "";
            if (dto.UserName==null)
            {
                rtn = "登录失败，请输入账号！";
                
            }
            var info= _context.Users.Where(t => t.UserName == dto.UserName).FirstOrDefault();
            if (info!=null&& info.Password==dto.Password)
            {
                rtn = "登录成功";
               
                return RedirectToAction("list");
            }
            rtn = "登录失败，账号密码不对！";
            ViewBag.error = rtn;
            return View("login");
        }

        //编辑页面
        public IActionResult Edit([FromQuery] int id)
        {
           
            return View(_context.Users.Find(id));
        }

        //添加页面
        public IActionResult Add()
        {
            return View();
        }

        //删除方法
        public bool Del([FromQuery] int id)
        {
            //主从删除
            var model = _context.Users.Find(id);
            _context.Users.Remove(model);
            _context.SaveChanges();
            return true;
        }

        [HttpGet]

        //详情页面
        public IActionResult Detail([FromQuery]int id)
        {
            return View(_context.Users.Find(id));
        }

        //列表页面
        public IActionResult List()
        {
            return View(_context.Users.ToList());
        }

        //新增编辑方法 主表
        [HttpPost]
        [ValidateAntiForgeryToken] //阻止CSRF攻击 
        public IActionResult Save(DbUser model)
        {
            //模型验证不通过 筛查问题
            if (!ModelState.IsValid)
            {
                var msg = string.Empty;
                foreach (var value in ModelState.Values)
                {
                    if (value.Errors.Count > 0)
                    {
                        foreach (var error in value.Errors)
                        {
                            msg = msg + error.ErrorMessage;
                        }
                    }
                }
                
            }


            if (ModelState.IsValid)
            {
                if (model.Id>0)
                {
                    //主从修改
                    _context.Entry(model).State = EntityState.Modified;
                    var role = _context.Roles.Where(t => t.UserId == model.Id).ToList();
                    role.ForEach(t =>
                    {
                        t.RoleName = "hh";
                    });
                    model.Roles = role;
                    _context.SaveChanges();
                    return RedirectToAction("List");

                }
                else
                {
                    //主从添加
                    var role = new List<DbRole>{ new DbRole { UserId = model.Id, RoleName = "角色1" } };
                    model.Roles=role;
                    _context.Users.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("List");
                   
                }
              
            }
            return View(model);
        }


        
    }
}
