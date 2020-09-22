using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuilderDesignPattern.Data;
using BuilderDesignPattern.Models;
using Microsoft.AspNetCore.Http;
using BuilderDesignPattern.Builders.ComputerBuilder;
using BuilderDesignPattern.Builders.ComputerBuilder.ConcreteBuilder;
using BuilderDesignPattern.Builders.Director;

namespace BuilderDesignPattern.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly BuilderDesignPatternContext _context;

        public EmployeesController(BuilderDesignPatternContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult BuildComputerSystem(int ? id)
        {
            Employee emp = _context.Employee.Find(id);
            ViewBag.employeeId = id;
            if (emp.ComputerDetails.Contains("Leptop"))
                
                return View("BuildLeptop");
            else
                return View("BuildDesktop");

        }
        //Post For Desktop
        [HttpPost]
        public IActionResult BuildDesktop( IFormCollection collection)
        {
            if (collection["employeeId"].ToString() == "")
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Step 1
                    Employee employee = _context.Employee.Find(Convert.ToInt32(collection["employeeId"]));
                    //step 2 concreate Builder
                    IComputerSystemBuilder computerSystem = new DesktopBuilder();
                    //step 3 Director 
                    ComputerConfigarationBuilder builder = new ComputerConfigarationBuilder();
                    builder.BuildSystem(computerSystem,collection);
                    ComputerSystem computer = computerSystem.GetSystem();
                    employee.ComputerSystemConfiguration = string.Format("RAM : {0},HardDrive : {1},GraphicsCard : {2},Mouse : {3},Keyborad : {4},Monitor : {5}", computer.RAM, computer.HardDrive, computer.GraphicsCard, computer.Mouse, computer.Keyborad, computer.Monitor);
                    _context.Employee.Update(employee);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(Convert.ToInt32(collection["employeeId"])))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
          
        }
        //Post For Leptop
        [HttpPost]
        public IActionResult BuildLeptop(IFormCollection collection)
        {
            if (collection["employeeId"].ToString() == "")
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Step 1
                    Employee employee = _context.Employee.Find(Convert.ToInt32(collection["employeeId"]));
                    //step 2 concreate Builder
                    IComputerSystemBuilder computerSystem = new LeptopBuilder();
                    //step 3 Director 
                    ComputerConfigarationBuilder builder = new ComputerConfigarationBuilder();
                    builder.BuildSystem(computerSystem, collection);
                    ComputerSystem computer = computerSystem.GetSystem();
                    employee.ComputerSystemConfiguration = string.Format("RAM : {0},HardDrive : {1},GraphicsCard : {2}", computer.RAM, computer.HardDrive, computer.GraphicsCard);
                    _context.Employee.Update(employee);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(Convert.ToInt32(collection["employeeId"])))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View();

        }
        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Designation,ComputerDetails,ComputerSystemConfiguration")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

       [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Designation,ComputerDetails,ComputerSystemConfiguration")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
