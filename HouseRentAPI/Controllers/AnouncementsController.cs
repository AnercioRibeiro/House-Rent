
using AutoMapper;
using HouseRentAPI.Models;
using HouseRentAPI.Models.DTOs;
using HouseRentAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HouseRentAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
   //[ApiExplorerSettings(GroupName = "ParkyOpenAPISpecNP")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class AnouncementsController : ControllerBase
    {
        private readonly IAnouncementRepository _anounceRepo;
        private readonly IMapper _mapper;
        //private readonly IUnitOfWork _unitOfWork;

        public AnouncementsController(IAnouncementRepository anounceRepo, IMapper mapper)
        {
            _anounceRepo = anounceRepo;
            _mapper = mapper;

        }
        //public NationalParksController(IUnitOfWork unitOfWork, IMapper mapper)
        //{
        //    _unitOfWork = unitOfWork;
        //    _mapper = mapper;
        //}
        /// <summary>
        /// Get list of national parks.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        //public IActionResult GetNationalParks()
        //{
        //    var nationParkList = _nationalRepo.GetNationalParks();

        //    var nationParkDTO = new List<NationalParkDTO>();

        //    foreach (var nationPark in nationParkList)
        //    {
        //        nationParkDTO.Add(_mapper.Map<NationalParkDTO>(nationPark));

        //    }

        //    return Ok(nationParkDTO);
        //}

        public IActionResult GetAnouncements()
        {
            var anouncementList = _anounceRepo.GetAnouncements();

            var anounceDTO = new List<AnouncementDTO>();
            foreach (var anounce in anouncementList)
            {
                anounceDTO.Add(_mapper.Map<AnouncementDTO>(anounce));

            }

            return Ok(anounceDTO);
        }

        ///// <summary>
        ///// Get individual national park
        ///// </summary>
        ///// <param name="anouncementId">The Id of Anouncement</param>
        ///// <returns></returns>
        [HttpGet("{anouncementId:int}", Name = "GetAnouncement")]
        [ProducesResponseType(200, Type = typeof(AnouncementDTO))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetAnouncement(int anouncementId)
        {
            var anouncentObj = _anounceRepo.GetAnouncement(anouncementId);
            if (anouncentObj == null)
            {
                return NotFound();
            }
            var anouncementDTO = _mapper.Map<AnouncementDTO>(anouncentObj);

            //if we do not use the automapper _mapper, we must to convert NationalPark into nationalParkDTO like this
            //var nationalParkDTO = new NationalPark() 
            //{
            //    Created = nationalParkObj.Created,
            //    Established = nationalParkObj.Established,
            //    Id = nationalParkObj.Id,
            //    Name = nationalParkObj.Name,
            //    State = nationalParkObj.State,
            //};

            return Ok(anouncementDTO);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(List<AnouncementCreateDTO>))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] AnouncementCreateDTO anouncementDTO)
        {
            if (anouncementDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var anouncementObj = new Anouncement()
            {
                Id = anouncementDTO.Id,
                Address = anouncementDTO.Address,
                Description = anouncementDTO.Description,
                Dimension = anouncementDTO.Dimension,
                Elevator = anouncementDTO.Elevator,
                EnergyType = anouncementDTO.EnergyType,
                FinishDate = anouncementDTO.FinishDate,
                Floor = anouncementDTO.Floor,
                HouseTypology = anouncementDTO.HouseTypology,
                Identifier = Int32.Parse(_anounceRepo.GenerateRandomIdentifier(anouncementDTO.Identifier)),
                InitialDate = anouncementDTO.InitialDate,
                Latitude = anouncementDTO.Latitude,
                Longitude = anouncementDTO.Longitude,
                Parking = anouncementDTO.Parking,
                Picture = anouncementDTO.Picture,
                ProvinceId = anouncementDTO.ProvinceId,
                SuiteNumber = anouncementDTO.SuiteNumber,
                Typology = anouncementDTO.Typology,
                WaterFount = anouncementDTO.WaterFount
            };

            if (!_anounceRepo.CreateAnouncement(anouncementObj))
            {
                ModelState.AddModelError("", $"Something went wrong when trying to saving the record {anouncementObj.Identifier}");
                return StatusCode(500, ModelState);
            }
            return Ok(anouncementObj);
        }

        //public IActionResult GenerateRandomIdentifier(int indentifier)
        //{
        //    var obj = _anounceRepo.GetAnouncements();
        //    var anouncementDTO = _mapper.Map<AnouncementDTO>(obj);
        //    _anounceRepo.AnouncementExists(anouncementDTO.Identifier);
        //    return Ok();
        //}
        [HttpPatch("{anouncementId:int}", Name = "Get")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(int anouncementId, [FromBody] AnouncementUpdateDTO anouncementUpdateDTO)
        {
            if (anouncementUpdateDTO == null || anouncementId!= anouncementUpdateDTO.Id)
            {
                return BadRequest(ModelState);
            }
            var anouncementObj = _mapper.Map<Anouncement>(anouncementUpdateDTO);
            if (!_anounceRepo.UpdateAnouncement(anouncementObj))
            {
                ModelState.AddModelError("", $"Algo errado aconteceu ao tentar editar  {anouncementObj.Identifier}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }


    }
}
